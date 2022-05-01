using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerState : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialFacing;
    public bool initialCanMove = true;

    [NonSerialized] public Vector2 facing;
    [NonSerialized] public bool canMove = true;

    public void OnAfterDeserialize()
    {
        facing = initialFacing; 
        canMove = initialCanMove; 
    }

    public void OnBeforeSerialize()
    {
        
    }
}
