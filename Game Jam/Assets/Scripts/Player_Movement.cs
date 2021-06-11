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
    
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;

    private void Awake() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal"); //(-1 to +1)

        rigidBody.velocity = new Vector2(moveDirection * moveSpeed, rigidBody.velocity.y);

    }
}
