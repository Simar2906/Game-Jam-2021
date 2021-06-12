using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float lateralDistance = 1f;
    private Transform pos1;
    private Transform pos2;

    private bool turnback;
    void Awake()
    {
        pos1.position = new Vector2(transform.position.x - lateralDistance, transform.position.y);
        pos2.position = new Vector2(transform.position.x + lateralDistance, transform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
