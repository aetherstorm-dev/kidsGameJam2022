using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour, IInteractionReceiver
{
    public VariableStore store;

    public void Interact()
    {
        if (!store.GetBool("player_has_garbage"))
        {
            store.SetBool("player_has_garbage", true);
            GameObject.Destroy(gameObject);
        }
    }

    public bool ShouldPassThrough()
    {
        return false;
    }
}
