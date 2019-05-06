using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public Animator animator;
    public float timeSlowed;
    public float timeSped;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (IsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            TimeHandler();
        }

        animator.SetBool("ifIsPaused", IsPaused);
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1;
    }

    void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0;
    }

    void Quit()
    {
        //Application.Quit();
    }

    void TimeHandler()
    {
        //Mathf.Lerp();
    }
}
