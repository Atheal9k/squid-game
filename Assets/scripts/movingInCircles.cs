using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingInCircles : MonoBehaviour {

    /*  public float RotateSpeed = 5f;
      public float Radius = 0.1f;
      private float timeBtwMove;
      public float startTimeBtwMove;

      private Vector2 centre;
      private float angle;

      private void Start()
      {
          centre = transform.position;
      }

      private void Update()
      {
          startTimeBtwMove -= Time.deltaTime;
          if (startTimeBtwMove <= 0)
          {
              angle += RotateSpeed * Time.deltaTime;

              var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
              transform.position = centre +offset;
          }

      } */

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 2f;

    float posX, posY, angle = 0f;

    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
            angle = 0f;
    }
}
