using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class DialogueUI : MonoBehaviour, DialogueListener
{
    public VariableStore store;
    public DialogueSystem dialogueSystem;
    public TextMeshProUGUI textUI;
    private CanvasGroup _canvasGroup;
    private DialogueNode currentDialogue = null;

    public void CancelDialogue()
    {
        _canvasGroup.alpha = 0f;
        dialogueSystem.inDialogue = false;
    }

    public void StartDialogue(DialogueNode node)
    {
        _canvasGroup.alpha = 1.0f;
        currentDialogue = node;

        dialogueSystem.inDialogue = true;

        ContinueDialogue();
    }

    public void ContinueDialogue()
    {
        string text;
        (currentDialogue, text) = WalkNode(currentDialogue);

        if (currentDialogue == null)
            CancelDialogue();

        textUI.text = text;
    }

    /// <summary>
    /// Executes a node tree until it hits a dialogue line, returning the text. Skips over root node!
    /// </summary>
    /// <returns>A new root and its text.</returns>
    private (DialogueNode, string) WalkNode(DialogueNode node)
    {
        if (node == null) return (null, null);

        foreach (DialogueAction action in node.afterActions)
        {
            ExecuteAction(action);
        }

        DialogueNode choice = null;
        foreach (DialogueNode branch in node.nodes)
        {
            bool valid = true;
            foreach (DialogueCondition condition in branch.conditions)
            {
                int value = store.GetInt(condition.key);
                switch (condition.comparison)
                {
                    case DialogueCondition.Comparison.LessThan:
                        valid &= value < condition.value; 
                        break;
                    case DialogueCondition.Comparison.LessThanOrEqual:
                        valid &= value <= condition.value;
                        break;
                    case DialogueCondition.Comparison.Equal:
                        valid &= value == condition.value;
                        break;
                    case DialogueCondition.Comparison.MoreThan:
                        valid &= value > condition.value;
                        break;
                    case DialogueCondition.Comparison.MoreThanOrEqual:
                        valid &= value >= condition.value;
                        break;
                    default:
                        Debug.LogError("[Dialogue] Unknown comparison " + condition.comparison + " in " + node.name);
                        break;
                }
            }

            if (valid)
            {
                choice = branch;
                break;
            }
        }

        if (choice != null)
        {
            foreach (DialogueAction action in choice.beforeActions)
            {
                ExecuteAction(action);
            }

            if (choice.empty)
                (choice, _) = WalkNode(choice); // risky recursion; walks straight through empty text

            if (choice != null)
                return (choice, choice.text);
        }

        return (null, null);
    }

    private void ExecuteAction(DialogueAction action)
    {
        switch (action.action)
        {
            case DialogueAction.Action.TriggerAction:
                dialogueSystem.Action(action.key, action.value);
                break;
            case DialogueAction.Action.SetVariable:
                store.SetInt(action.key, int.Parse(action.value));
                break;
            case DialogueAction.Action.AddVariable:
                store.AddInt(action.key, int.Parse(action.value));
                break;
            case DialogueAction.Action.ClearVariable:
                store.SetInt(action.key, 0);
                break;
            default:
                Debug.LogError("[Dialogue] Unknown action " + action.action);
                break;
        }
    }

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
    
        dialogueSystem.RegisterListener(this);
    }

    private void OnDestroy()
    {
        dialogueSystem.UnregisterListener(this);
    }
}
