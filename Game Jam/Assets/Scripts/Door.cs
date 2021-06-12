using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake() 
    {
        //gameManager = GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Touched Door");
            if(gameManager.keyAcquired)
            {
                Debug.Log("Level has ended");
                gameManager.EndGame();
            }
        }
    }
}
