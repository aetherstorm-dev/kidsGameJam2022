using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerState state;
    public float speed = 10f;

    private Controls controls;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Vector2 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); // Animator required, never null. Hopefully.
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
        if (_movement.magnitude > 0)
            state.facing = _movement.normalized;
    }

    private void FixedUpdate()
    {
        if (state.canMove)
            _rigidBody.velocity = _movement.normalized * speed * Time.deltaTime;
        else
            _rigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (state.canMove)
        {
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Speed", _movement.magnitude);
        }
    }
}
