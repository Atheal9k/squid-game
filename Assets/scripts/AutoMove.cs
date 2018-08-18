using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    
    public float speed;

    public bool isAllowedToMove = true;
    
    void Start()
    {
        GameObject Hazards = GameObject.FindWithTag("hazard");
       // enableMove.GetComponent<AutoMove>().isAllowedToMove = true;

    }

    void Update()
    {

        if (!isAllowedToMove)
        {
            speed = 0;
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else
        {
            moveDown();
        }
        
         
    }

    void moveDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    
}
