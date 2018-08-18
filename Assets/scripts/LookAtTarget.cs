using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

    public Transform target;
    //public float speed = 5f;
    //GameObject target;

    void Start()
    {
        // target = GameObject.Find("Player");
    }

    void Update()
    {
        // Vector2 direction = target.position - transform.position;
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = transform.LookAt(target);
        //Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime); */

        //  Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        // transform.LookAt(targetPosition); 
        targetDir();

       
    }

    void targetDir()
    {
        
        Vector2 direction = target.position - transform.position;
        transform.up = direction;
       
    }

   


}
