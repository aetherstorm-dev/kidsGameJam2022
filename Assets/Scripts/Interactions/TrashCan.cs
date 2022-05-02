using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractionReceiver
{
    public VariableStore store;

    public void Interact()
    {
        if (store.GetBool("player_has_garbage"))
        {
            store.SetBool("player_has_garbage", false);
            store.AddInt("garbage_cleaned", 1);
            store.AddInt("score", 1);
        }
    }

    public bool ShouldPassThrough()
    {
        return false;
    }
}
