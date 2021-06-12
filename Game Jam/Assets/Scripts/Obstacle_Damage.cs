using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Damage : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player = null;
    private int health;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = FindObjectOfType<GameManager>().lives;
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<GameManager>().lives = health;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Damage();
        }
        if(health <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    private void Damage()
    {
        Debug.Log("Damaged");
        health -= 1;
    }

    
}
