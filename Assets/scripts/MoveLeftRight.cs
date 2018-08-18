using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{

    /*  [SerializeField]
      float moveSpeed = 5f;

      [SerializeField]
      float frequency = 20f;

      [SerializeField]
      float magnitude = 0.5f;

      bool facingRight = true;

      Vector3 pos, localScale;


      void Start () {
          pos = transform.position;

          localScale = transform.localScale;
      }


      void Update () {
          CheckWhereToFace();

          if (facingRight)
              MoveRight();
          else
              MoveLeft();
      }

      void CheckWhereToFace()
      {
          if (pos.x < -1.5f)
              facingRight = true;
          else if (pos.x > 1.5f)
              facingRight = false;

          if (((facingRight) && (localScale.x < 0)) || ((facingRight) && (localScale.x > 0)))
              localScale.x *= -1;

          transform.localScale = localScale;
      }

      void MoveRight()
      {
          pos += transform.right * Time.deltaTime * moveSpeed;
          transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
      }

      void MoveLeft()
      {
          pos -= transform.right * Time.deltaTime * moveSpeed;
          transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
      } */

    /* private Vector3 pos1 = new Vector3(-1, 5, 0);
     private Vector3 pos2 = new Vector3(1, 0, 0);
     public float speed = 1.0f;

     void Update()
     {
         transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
     } */

    private bool dirRight = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 0.5f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -0.5)
        {
            dirRight = true;
        }
    }
}
