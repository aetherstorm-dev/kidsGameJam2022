using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pipe : MonoBehaviour, IInteractionReceiver
{
    public VariableStore store;
    public Sprite fixedSprite;
    
    private bool isFixed = false;
    private SpriteRenderer spriteRenderer;

    public void Interact()
    {
        if (isFixed) return;

        isFixed = true;
        store.SetInt("pipe_fixed", 1);
        store.AddInt("score", 1);
        spriteRenderer.sprite = fixedSprite;
    }

    public bool ShouldPassThrough()
    {
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
