using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerState : ScriptableObject
{
    public Vector2 facing;
    public bool canMove = true;
}
