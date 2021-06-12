using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Damage : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player = null;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Damage();

        }
    }
    private void Damage()
    {
        
    }

}
