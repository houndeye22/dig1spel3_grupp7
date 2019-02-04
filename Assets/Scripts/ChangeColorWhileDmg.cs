using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorWhileDmg : MonoBehaviour
{
    private Renderer rend;
    public Color unTargetable;
    public Color defaultColor;



    void Update()
    {

        if (HPScript.unTargetable == true)
        {
            rend = GetComponent<Renderer>();
            rend.material.color = unTargetable;
        }
        else
        {
            rend = GetComponent<Renderer>();
            rend.material.color = defaultColor;
        }
    }
}
