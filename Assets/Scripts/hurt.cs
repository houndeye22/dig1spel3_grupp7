using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //lägger till unityengines för scene managements
public class hurt : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {    //ifall ett objekt med tagen player koliderar med detta objektet aktiveras en ny scen
        if (collision.collider.tag == "Player")
        {
            Scene active = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active.name);
        }
    }

}
