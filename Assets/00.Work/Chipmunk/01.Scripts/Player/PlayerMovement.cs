using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Update = UnityEngine.PlayerLoop.Update;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Rigidbody2D rigidCompo;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool canJump = true;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckTrm;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
    private void Update()
    {
        Move();
    }
    [SerializeField] UnityEvent onCollsiionEnter = new UnityEvent();
    private void OnCollisionEnter2D(Collision2D other)
    {
        onCollsiionEnter.Invoke();
    }

    private void FixedUpdate()
    {
        if (canJump)
            Jump();
    }
    private void Move()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            Move(-1f);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            Move(1f);
        }
    }

    public void Move(float x)
    {
        rigidCompo.linearVelocityX = x * speed;
    }
    public bool IsGrounded()
    {
        Collider2D hit = Physics2D.OverlapCircle(groundCheckTrm.position, groundCheckRadius, groundLayer);
        Debug.Log(hit);
        return hit != null;
    }


    private void Jump()
    {
        if (IsGrounded())
        {
            rigidCompo.linearVelocityY = jumpForce;
            canJump = false;   
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if(IsGrounded())
            canJump = true;
    }
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckTrm.position, groundCheckRadius);
    }
    #endif
}
