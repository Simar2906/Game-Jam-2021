using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canavs_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives;
    public int numOfHearts;
    public GameManager gameManager;
    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private void Awake() 
    {
        gameManager = FindObjectOfType<GameManager>();
        lives = gameManager.lives;
        numOfHearts = gameManager.numOfHearts;
        hearts = GameObject.FindGameObjectsWithTag("Hearts");
        fullHeart = Resources.Load<Sprite>("Sprites/life");
        emptyHeart = Resources.Load<Sprite>("Sprites/empty life");
    }

    // Update is called once per frame
    void Update()
    {
        lives = gameManager.lives;
        numOfHearts = gameManager.numOfHearts;
        if(lives > numOfHearts)
        {
            lives = numOfHearts;
        }
        for( int i = 0; i< hearts.Length; i++)
        {
            if(i< lives)
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = fullHeart;
            }
            else
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
