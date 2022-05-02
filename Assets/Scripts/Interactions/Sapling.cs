using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Sapling : MonoBehaviour, IInteractionReceiver
{
    public VariableStore store;
    public Animator _animator;

    private bool sprouted = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (sprouted) 
            return;
        store.AddInt("trees_planted", 1);
        store.AddInt("score", 1);
        _animator.SetTrigger("sprout");

        sprouted = true;
    }

    public bool ShouldPassThrough()
    {
        return !sprouted;
    }
}
