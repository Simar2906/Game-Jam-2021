using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    private void Awake() 
    {
        //gameManager = GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Touched Key");
            gameManager.keyAcquired = true;
            Destroy(gameObject);
        }
    }
}
