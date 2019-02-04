using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHearts : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite hollowHeart;

    public int hpFull;
    public int hpHalf;
    public int hpHollow;


    void Update()
    {
        if (HPScript.healthRemaining >= hpFull)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fullHeart;
        }
        else if (HPScript.healthRemaining == hpHalf)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = halfHeart;
        }
        else if (HPScript.healthRemaining <= hpHollow)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hollowHeart;
        }
    }
}
