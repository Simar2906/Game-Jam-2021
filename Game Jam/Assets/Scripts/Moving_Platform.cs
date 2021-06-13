using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.5f;
    public float lateralDistance = 2f;
    private Vector2 pos1;
    private Vector2 pos2;
    private Rigidbody2D objectRigidBody;
    public bool dirRight = true;

    private bool turnback;
    private void Awake()
    {
        int right = 1;
        if (!dirRight){
        right = -1;
        }

        pos1 = new Vector2(transform.position.x - (lateralDistance * right), transform.position.y);
        pos2 = new Vector2(transform.position.x + (lateralDistance * right), transform.position.y);
        objectRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Player"))
        {
            other.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        other.collider.transform.SetParent(null);
    }

}
