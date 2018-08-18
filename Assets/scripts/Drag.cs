using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    //float dragZone = 0.5f;
    //float moveSpeed = 1f;
  

    /* float deltaX, deltaY;

     Rigidbody2D rb;

     bool moveAllowed = false;

     void Start () {
         rb = GetComponent<Rigidbody2D>();	
     }


     void Update () {
         if (Input.touchCount > 0)
         {
             Touch touch = Input.GetTouch(0);
             Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
             switch (touch.phase)
             {
                 case TouchPhase.Began:
                     if (GetComponent<Collider2D> () == Physics2D.OverlapPoint(touchPos)){
                         deltaX = touchPos.x - transform.position.x;
                         deltaY = touchPos.y - transform.position.y;
                         moveAllowed = true;
                         rb.freezeRotation = true;
                         //rb.velocity - new Vector2(0, 0);
                         rb.gravityScale = 0;


                     }
                     break;

                 case TouchPhase.Moved:
                     if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                         rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                     break;
             }
         }
     } */

    /* float distance = 10;

    void OnMouseDrag()
    {
        
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
        print(objPosition);
    } */

    private Vector3 screenPoint;
    private Vector3 offset;


    // public Vector3 dragDelta;
    //private Vector3 lastDragPosition = screenPoint;


    public bool canDrag = true;
    public bool isDragging = false;
    public HoldMove holdmove;
    Touch touch;


   void OnMouseDown()
    {
        if (canDrag)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            //print("down");
            isDragging = true;
            //GameObject enableTH = GameObject.FindWithTag("player");
            //enableTH.GetComponentInParent<HoldMove>().enabled = false;
        }

        else if (!canDrag)
        {
            //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            //print("cantdrag");
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, screenPoint.z));
        }

        

    


    }

   void OnMouseUp()
    {
        
        
           // print("up");
           isDragging = false;
        
          //  GameObject enableTH = GameObject.FindWithTag("player");
            //enableTH.GetComponentInParent<HoldMove>().enabled = true;
        
    }

    void OnMouseDrag()
    {

        if (canDrag)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;
            //holdmove.canSlow = false;
            Time.timeScale = 1f;



        }


        if (!canDrag)
        {
            //print("cantdrag2");
            Vector3 curScreenPoint = new Vector3(screenPoint.x, screenPoint.y, screenPoint.z);
           // Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            //transform.position = curPosition;
        }



        




    }
    
  
    
    


    

}



