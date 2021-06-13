using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager;
    public float rotateSpeed = 1f;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touched Coin");
            gameManager.coinAmount += 1;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
        if(gameManager.coinAmount >= 3)
        {
            gameManager.coinAmount -= 3;
            //incearsing health
            FindObjectOfType<GameManager>().lives += 1;
        }
    }
}
