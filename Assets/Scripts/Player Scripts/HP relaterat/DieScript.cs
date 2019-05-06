using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieScript : MonoBehaviour
{
    public string sceneToLoad = "Level1";

    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpoint;
    }

    void Update()
    {
        if (HPScript.healthRemaining <= 0)
        {
            HPScript.unTargetable = false;
            Movement.canMove = false;
            Invoke("Respawn", 2f);  
        }
    }

    void Respawn()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
