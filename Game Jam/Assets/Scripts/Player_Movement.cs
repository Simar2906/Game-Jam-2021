using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody = null;
    private bool facingRight = true;
    private float moveDirection;
    public float moveSpeed;
    public Animator animator;

    public KeyCode jumpKey = KeyCode.W;

    public float jumpForce;
    private bool isJumping = false;
    private void Awake() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // change velocity variables and animation speed
        ProcessMethod();
        // change sprite direction
        DirectionChange();
        //change animation
        Animate();

    }

    private void FixedUpdate() 
    {
        //move
        Move();
    }
    private void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection * moveSpeed, rigidBody.velocity.y);
        if(isJumping)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;

    }

    private void Animate()
    {
        animator.SetFloat("speed", Mathf.Abs(moveDirection));
    }

    private void DirectionChange()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessMethod()
    {
        moveDirection = Input.GetAxis("Horizontal"); //(-1 to +1)
        if(Input.GetKeyDown(jumpKey))
        {
            Debug.Log("Jumping");
            isJumping = true;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
