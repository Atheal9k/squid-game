using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    /* public Transform target;
     //public float smoothSpeed = .3f;

     private Vector3 currentVelocity;

    
    if (screenPosition.y > Screen.height || screenPosition.y < 0)


    void Start()
    {
        
    }

    void LateUpdate()
     {
    Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
    if (target.position.y > transform.position.y)
         {
             //Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
             //transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed);
             transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);

         }
     } 


    

    */

    public Transform target;
    public float followSharpness = 0.1f;
    const float REFERENCE_FRAMERATE = 30f;

    Vector3 _followOffset;
    Vector3 previousPos;
    void Start()
    {
        // Cache the initial offset at time of load/spawn:
        _followOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Apply that offset to get a target position.
        Vector3 targetPosition = target.position + _followOffset;
        // Keep our x position unchanged
        targetPosition.x = transform.position.x;
        previousPos.y = targetPosition.y - transform.position.y;
        // Smooth follow.    
       // if (transform.position.y > target.position)
       // {
       //     print("TARp" + targetPosition.y);
       //     print("trans" + transform.position.y);
            transform.position += (targetPosition - transform.position) * followSharpness;
       // }
        

        float timeRatio = Time.deltaTime * REFERENCE_FRAMERATE;
        float adjustedSharpness = 1f - Mathf.Pow(1f - followSharpness, timeRatio);

        transform.position += (targetPosition - transform.position) * adjustedSharpness;
    }


}
