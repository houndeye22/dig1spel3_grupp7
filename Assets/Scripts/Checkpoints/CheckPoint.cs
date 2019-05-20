using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject player;
    private GameMaster gm;

    private Renderer rend;
    public Color active;
    public Color notActive;




    void Start()
    {
        rend = GetComponent<Renderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.lastCheckpoint = transform.position;
    }

    private void Update()
    {
        if (gm.lastCheckpoint.x == transform.position.x && gm.lastCheckpoint.y == transform.position.y)
        {
            rend.material.color = active;
        }
        else
        {
            rend.material.color = notActive;
        }
    }
}
