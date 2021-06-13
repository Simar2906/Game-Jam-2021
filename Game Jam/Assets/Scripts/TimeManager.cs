using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Update () {
        if (Input.GetKey(KeyCode.J))
        {
            Time.timeScale = 0.65f;
        }
        else
            Time.timeScale = 1;
    }
    /*public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    void Update() 
    {
        Time.timeScale += (1f / slowdownLength) * Time.fixedDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }*/
}
