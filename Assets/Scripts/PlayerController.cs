using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Vector2 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); // Animator required, never null. Hopefully.
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _movement.normalized * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.magnitude);
    }
}
