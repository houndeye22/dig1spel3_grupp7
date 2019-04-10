using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster intance;
    public Vector2 lastCheckpoint;

    private void Awake()
    {
        if (intance == null)
        {
            intance = this;
            DontDestroyOnLoad(intance);
        }
        else
            Destroy(gameObject);
    }
}
