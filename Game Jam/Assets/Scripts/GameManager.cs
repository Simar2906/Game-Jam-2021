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
    public GameObject[] darkMovingArray;
    public GameObject[] lightMovingArray;
    public bool dark = true;

    public bool keyAcquired = false;
    public SpriteRenderer spriteRenderer;
    public Animator player_Animator;

    public float timeswitching =0.4f;
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
        
        darkMovingArray = GameObject.FindGameObjectsWithTag("Dark Moving Platform");
        lightMovingArray = GameObject.FindGameObjectsWithTag("Light Moving Platform");

        player = GameObject.FindGameObjectWithTag("Player");
        player_Animator = player.GetComponent<Animator>();
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
            dark = !dark;  
        }

        if (Input.GetKey(KeyCode.J))
        {
            Time.timeScale = timeswitching;
        }
        else{
            Time.timeScale = 1;
        }
            
    }

    private void ThemeChange()
    {
        if (dark)
        {
            player_Animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/controller_dark");
            foreach (GameObject light in lightArray)
            {
                light.SetActive(false);
            }
            foreach (GameObject dark in darkArray)
            {
                dark.SetActive(true);
            }
            //spriteRenderer.sprite = differentSprite;
            foreach (GameObject lightPlat in lightMovingArray)
            {
                lightPlat.GetComponent<SpriteRenderer>().enabled = false;
                lightPlat.GetComponent<BoxCollider2D>().enabled = false;
            }
            foreach (GameObject darkPlat in darkMovingArray)
            {
                darkPlat.GetComponent<SpriteRenderer>().enabled = true;
                darkPlat.GetComponent<BoxCollider2D>().enabled = true;
            }

        }
        else
        {
            player_Animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/controller_light");
            foreach (GameObject light in lightArray)
            {
                light.SetActive(true);
            }
            foreach (GameObject dark in darkArray)
            {
                dark.SetActive(false);
            }
            foreach (GameObject lightPlat in lightMovingArray)
            {
                lightPlat.GetComponent<SpriteRenderer>().enabled = true;
                lightPlat.GetComponent<BoxCollider2D>().enabled = true;
            }
            foreach (GameObject darkPlat in darkMovingArray)
            {
                darkPlat.GetComponent<SpriteRenderer>().enabled = false;
                darkPlat.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
