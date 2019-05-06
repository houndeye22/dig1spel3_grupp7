using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadowSpawner : MonoBehaviour
{

    public GameObject player;

    public Movement mov;
    public float maxTime = 0.25f;
    public float timePassed;
    //public SpriteRenderer spawnDashShadow;
    public float spriteVis;
    public GameObject dashShadow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        if (mov.isDashing == true)
        {
            timePassed += Time.deltaTime;
            if (timePassed <= maxTime)
            {
                Instantiate(dashShadow, new Vector3(mov.transform.position.x, mov.transform.position.y, mov.transform.position.z), transform.rotation);
            }
        }
        else
        {
            timePassed = 0;
        }

        if (spriteVis >= 0)
        {
            spriteVis -= 0.05f;
        }
    }
}