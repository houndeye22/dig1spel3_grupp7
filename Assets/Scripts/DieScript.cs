using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieScript : MonoBehaviour
{
    public string sceneToLoad = "Level1";

    void Update()
    {
        if (HPScript.healthRemaining == 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
