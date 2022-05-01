using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public DialogueNode dialogue;

    public void TriggerDialogue()
    {
        if (!dialogueSystem.inDialogue)
            dialogueSystem.StartDialogue(dialogue);
        else
            dialogueSystem.ContinueDialogue();
    }
}
