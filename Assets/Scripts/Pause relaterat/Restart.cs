using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public Scene m_Scene;
    public string sceneName;

    // Start is called before the first frame update
    private void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
