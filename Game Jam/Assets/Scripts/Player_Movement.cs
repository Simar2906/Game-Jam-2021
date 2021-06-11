using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController2D player = null;
    
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;

    private void Awake() 
    {
        player = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveLeft()
    {

    }
    void SetMoveVector()
    {

    }
}
