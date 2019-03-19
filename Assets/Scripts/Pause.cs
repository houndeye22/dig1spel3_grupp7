using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{

    public TextMeshProUGUI text1;

    public bool isPaused;

    private void Start()
    {
        text1 = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isPaused == true)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        text1.SetText(" ");
    }

    void Paused()
    {
        isPaused = true;
        Time.timeScale = 0;
        text1.SetText("Paused");
    }

}
