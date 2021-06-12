using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    bool gameHasEnded = false;

    public float restartDelay = 1f;
    public void EndGame ()
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

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}