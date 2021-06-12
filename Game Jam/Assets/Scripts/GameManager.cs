using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public GameObject player = null;
    public int lives = 3;
    public float restartDelay = 1f;
    public GameObject[] darkArray;
    public GameObject[] lightArray;
    public bool dark = true;

    public bool keyAcquired = false;
    public SpriteRenderer spriteRenderer;
    //public TimeManager timeManager;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }
    private void Awake()
    {
        darkArray = GameObject.FindGameObjectsWithTag("Dark Platform");
        lightArray = GameObject.FindGameObjectsWithTag("Light Platform");
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = player.GetComponent<SpriteRenderer> ();
    }
    private void Update()
    {
        ThemeChange();
        Switching();
    }
    void Switching()
    {

        if (Input.GetKeyDown(KeyCode.J)) //left key: 0
        {
            //timeManager.DoSlowmotion();
            dark = !dark;  
        }
    }

    private void ThemeChange()
    {
        if (dark)
        {

            foreach (GameObject light in lightArray)
            {
                light.SetActive(false);
            }
            foreach (GameObject dark in darkArray)
            {
                dark.SetActive(true);
            }
            //spriteRenderer.sprite = differentSprite;

        }
        else
        {
            foreach (GameObject light in lightArray)
            {
                light.SetActive(true);
            }
            foreach (GameObject dark in darkArray)
            {
                dark.SetActive(false);
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
