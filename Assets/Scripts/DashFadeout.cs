using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashFadeout : MonoBehaviour
{

    public float shadowCol = 1;
    public SpriteRenderer shadow;
    public float reductionAmount = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        shadowCol -= 0.1f;
        if (shadow.color.a > -reductionAmount)
        {
            shadow.color = new Color(1, 1, 1, shadowCol);
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
}
