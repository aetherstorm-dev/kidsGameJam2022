using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueSystem : ScriptableObject
{
    private List<DialogueListener> listeners =
        new List<DialogueListener>();

    private List<(string, DialogueActionListener)> actionListeners =
        new List<(string, DialogueActionListener)>();

    public bool inDialogue = false;

    public void RegisterListener(DialogueListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(DialogueListener listener)
    { listeners.Remove(listener); }

    public void RegisterActionListener(DialogueActionListener listener, string key)
    { 
        actionListeners.Add((key, listener)); 
    }

    public void UnregisterActionListener(DialogueActionListener listener, string key)
    { 
        actionListeners.Remove((key, listener)); 
    }

    public void StartDialogue(DialogueNode node)
    {
        foreach (DialogueListener listener in listeners)
            listener.StartDialogue(node);
    }

    public void ContinueDialogue()
    {
        foreach (DialogueListener listener in listeners)
            listener.ContinueDialogue();
    }

    public void CancelDialogue()
    {
        foreach (DialogueListener listener in listeners)
            listener.CancelDialogue();
    }

    public void Action(string key, string argument)
    {
        bool received = false;
        foreach ((string value, DialogueActionListener listener) in actionListeners) 
        {
            if (value == key)
            {
                received = true;
                listener.OnDialogueAction(key, argument);
            }
        }

        if (!received)
            Debug.LogWarning("[Dialogue] Action " + key + " not picked up by any listeners. Did they forget to register?");
    }
}

public interface DialogueListener
{
    void StartDialogue(DialogueNode node);
    void ContinueDialogue();
    void CancelDialogue();
}

public interface DialogueActionListener
{
    void OnDialogueAction(string key, string argument);
}
