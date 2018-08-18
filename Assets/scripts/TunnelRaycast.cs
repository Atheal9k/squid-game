using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelRaycast : MonoBehaviour
{

    public Transform sightStart, sightEnd;

    public bool spotted = false;

    void Update()
    {
        Raycasting();
        Behaviours();
    }


    void Raycasting()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("tunnel"));

    }

    void Behaviours()
    {
        if (spotted == true)
        {
            GameObject startMove = GameObject.FindWithTag("tunnel1");
            startMove.GetComponent<TunnelOfDeath>().enabled = true;
            
            spotted = true;
            if (spotted == false)
            {
                spotted = true;
            }

        }
        if (spotted == false)
        {
            GameObject startMove = GameObject.FindWithTag("tunnel1");
            startMove.GetComponent<TunnelOfDeath>().enabled = false;
            
        }



    }

}
