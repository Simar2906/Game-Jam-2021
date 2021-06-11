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

    private void Awake() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal"); //(-1 to +1)

        rigidBody.velocity = new Vector2(moveDirection * moveSpeed, rigidBody.velocity.y);

        if(moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if(moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
