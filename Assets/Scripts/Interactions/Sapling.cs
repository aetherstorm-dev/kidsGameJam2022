using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(InteractionReceiver))]
public class Sapling : MonoBehaviour
{
    public VariableStore store;
    public Animator _animator;

    private bool sprouted = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Sprout()
    {
        if (sprouted) 
            return;
        store.AddInt("trees_planted", 1);
        _animator.SetTrigger("sprout");

        sprouted = true;
    }
}
