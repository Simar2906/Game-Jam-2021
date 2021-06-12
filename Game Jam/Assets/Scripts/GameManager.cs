using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public int lives = 3;
    public float restartDelay = 1f;
    public GameObject[] darkArray;
    public GameObject[] lightArray;
    public bool dark = true;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
            /*Need to add a new if condition on player_movement script to see if the object is falling or colliding with enemy 
            obejct*/
        }
    }
    private void Awake()
    {
        darkArray = GameObject.FindGameObjectsWithTag("Dark Platform");
        lightArray = GameObject.FindGameObjectsWithTag("Light Platform");

    }
    private void Update()
    {
        ThemeChange();
        Switching();
    }
    void Switching()
    {

        if (Input.GetMouseButtonDown(0)) //left key: 0
        {
            dark = !dark;
        }
    }

    private void ThemeChange()
    {
        if (dark)
        {

            foreach (GameObject light in lightArray)
            {
                Debug.Log(light);
                light.SetActive(false);
            }
            foreach (GameObject dark in darkArray)
            {
                dark.SetActive(true);
            }
            

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