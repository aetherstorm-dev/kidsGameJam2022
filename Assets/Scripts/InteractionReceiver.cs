using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionReceiver : MonoBehaviour
{
    public UnityEvent onTrigger;

    public void Trigger()
    {
        onTrigger.Invoke();
    }
}
