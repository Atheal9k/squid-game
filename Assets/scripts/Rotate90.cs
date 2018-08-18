using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate90 : MonoBehaviour {

   /* private float rotate;
    public float speed = 35f;
    public float fromRotation = 90f;
    public float toRotation = 1f;
    public bool ninety = false;
    private float waitTime1 =2f;
    private float waitTime2 = 2f;
    public float delayTime = 2f;

    void Start()
    {
        waitTime1 = delayTime;
        waitTime2 = delayTime;
        waitTime2 -= Time.deltaTime;
    }

    void Update()
    {
        

        if (transform.eulerAngles.z >= fromRotation)
        {
            ninety = true;
            waitTime1 -= Time.deltaTime;
            


        }

        if (ninety == true)
        {
            if (waitTime1 <= 0)
            {
                rotate -= Time.deltaTime;
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotate * speed);
                waitTime2 = delayTime;

            }



        }
       
        if (transform.eulerAngles.z <= toRotation)
        {
            ninety = false;
            waitTime2 -= Time.deltaTime;

        }

        if (ninety == false)
        {
           if (waitTime2 <= 0)
            {
                rotate += Time.deltaTime;
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotate * speed);
                waitTime1 = delayTime;
            }
               

   
        }
      
    } */

    public float speed = 2f;
    public float maxRotation = 45f;

    void Update()
    {
        transform.rotation = Quaternion.Euler (0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }

}


