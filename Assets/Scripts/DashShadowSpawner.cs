using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadowSpawner : MonoBehaviour
{

    public Movement mov;
    public float maxTime = 0.25f;
    public float timePassed;
    public SpriteRenderer dashShadow;
    public SpriteRenderer spawnDashShadow;
    public float spriteVis;

    // Start is called before the first frame update
    void Start()
    {

        //shadowColor = gameObject.GetComponent<Color>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mov.isDashing == true)
        {
            timePassed += Time.deltaTime;
            if (timePassed <= maxTime)
            {
                spawnDashShadow = Instantiate(dashShadow, transform.position, transform.rotation);
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

        //SpawnDashShadow.color = new Color(1, 1, 1, spriteVis);
    }
}
