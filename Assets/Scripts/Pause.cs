using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {

            ActivateMenu();
        }

        else
        {

            Deactivate();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {

            ActivateMenu();
        }

        else
        {

            Deactivate();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

    }

    public void Deactivate()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }


    public void DontPressThis()
    {
        Time.timeScale = 100;
        isPaused = false;
        HPScript.maxHealth = 1;
    }
}
