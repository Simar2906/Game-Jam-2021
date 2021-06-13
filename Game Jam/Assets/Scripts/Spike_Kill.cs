using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Kill : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You have died");
            gameManager.EndGame();
        }
    }
}
