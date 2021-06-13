using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(gameManager.keyAcquired)
            {
                Debug.Log("Level has Completed");
                FindObjectOfType<AudioManager>().Play("complete");
                gameManager.CompleteLevel();
            }
        }
    }
}
