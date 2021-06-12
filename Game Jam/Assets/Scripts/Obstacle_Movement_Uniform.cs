using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Movement_Uniform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float lateralDistance = 100f;
    private Vector2 pos1;
    private Vector2 pos2;
    private Rigidbody2D objectRigidBody;
    private bool dirRight = true;

    private bool turnback;
    private void Awake()
    {
        pos1 = new Vector2(transform.position.x - lateralDistance, transform.position.y);
        pos2 = new Vector2(transform.position.x + lateralDistance, transform.position.y);
        objectRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));   
    }


}
