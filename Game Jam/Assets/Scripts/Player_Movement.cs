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
    public float fallMultiplier = 2.5f;
    private Animator animator;

    public KeyCode jumpKey = KeyCode.W;

    public float jumpForce;
    public float jumpVelocity = 8f;
    private bool isJumping = false;

    public Transform groundCheck = null;
    public LayerMask groundObjects;

    private bool isGrounded;
    public float checkRadius;

    public float levelBottom = -50f;
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
        if(rigidBody.position.y < levelBottom)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        //Debug.Log(isGrounded);
    }
    private void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection * moveSpeed, rigidBody.velocity.y);
        if(isJumping)
        {
            rigidBody.velocity = Vector2.up * jumpVelocity;
            //rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
        if(rigidBody.velocity.y <0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
        }
        else if(rigidBody.velocity.y > 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;

        }
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
        if((Input.GetKeyDown(jumpKey) || Input.GetButtonDown("Jump")) && isGrounded)
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
