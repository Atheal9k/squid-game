using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelOfDeath : MonoBehaviour {

    public GameObject platform;
    public float moveSpeed;
    private Transform currentPoint;
    public Transform[] points;
    public int pointSelection;

    void Start()
    {
        currentPoint = points[pointSelection];
    }


    void Update()
    {
        /*if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= -0.3f)
        {
            
            dirRight = false;
        }

        if (transform.position.x <= -2)
        {
            
            dirRight = true;
        } */


        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if (platform.transform.position == currentPoint.position)
        {
            pointSelection++;

        }

        if (pointSelection == points.Length)
        {
            pointSelection = 0;
        }
        currentPoint = points[pointSelection];

    }

  /*  transform.Translate(Vector2.right* speed * Time.deltaTime);

    RaycastHit2D otherTun = Physics2D.Raycast(detect.position, Vector2.right, range);
        if (otherTun.collider == false)
        {
            if(dirRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
    dirRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
dirRight = true;
            }
        }*/
}
