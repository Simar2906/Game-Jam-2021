using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform_Vertical : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float verticalDistance = 10f;
    private Vector2 pos1;
    private Vector2 pos2;
    private Rigidbody2D objectRigidBody;
    private bool dirRight = true;

    private bool turnback;
    private void Awake()
    {
        pos1 = new Vector2(transform.position.x , transform.position.y - verticalDistance);
        pos2 = new Vector2(transform.position.x , transform.position.y + verticalDistance);
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
