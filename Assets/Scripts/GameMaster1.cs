using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster1 : MonoBehaviour
{
    private static GameMaster1 instance;
    public Vector2 lastCheckPointPos;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }
}
