using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayAnimation : MonoBehaviour, DialogueActionListener
{
    public DialogueSystem dialogueSystem;
    public string listenAction;
    public string triggerName;
    private Animator _animator;

    public void OnDialogueAction(string key, string argument)
    {
        _animator.SetTrigger(triggerName);
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        if (listenAction == null || triggerName == null)
        {
            Debug.LogWarningFormat("{0}: Neither Listen Action or Trigger Name can be null; not registering for event.");
            return;
        }

        dialogueSystem.RegisterActionListener(this, listenAction);
    }
}
