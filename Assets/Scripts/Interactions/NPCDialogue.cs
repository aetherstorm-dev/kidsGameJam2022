using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour, IInteractionReceiver
{
    public DialogueSystem dialogueSystem;
    public DialogueNode dialogue;

    public void Interact()
    {
        if (!dialogueSystem.inDialogue)
            dialogueSystem.StartDialogue(dialogue);
        else
            dialogueSystem.ContinueDialogue();
    }

    public bool ShouldPassThrough()
    {
        return false;
    }
}
