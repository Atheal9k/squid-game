using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EZCameraShake;

public class HoldMove : MonoBehaviour
{





    [SerializeField]
    float moveSpeed = 12f;
    //float chargedVelo = 0f;
    float holdingTime;
    float zero = 0f;
    float zeroPointFive = 0.51f;
   



    Rigidbody2D rb;


    Vector3 previous;
    float velocity;
    Touch touch;
    private Renderer rend;

    //private float holdTime = 0.1f; 
    //private float acumTime = 0.08f;

    Vector3 touchPosition, whereToMove;
    Vector3 start;
    Vector3 target;
    float slowingDistance;
    public bool isMoving = false;
    //bool isTouching = false;
    public bool isMidMove;
    public string midMove = "n";
    public string levelToLoad;
    public Drag drag;
    public bool isTouching;
    public bool mouseDrag = false;
    public bool canSlow = false;
    public bool isCharging;
    private bool level1Move = false;
    private bool level2Move = false;
    private bool level3Move = false;

    public GameManager gameManager;
    public GameObject TapChargeParticle;

    private IEnumerator coroutine;


    float previousDistanceToTouchPos, currentDistanceToTouchPos;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();

    }


    void Update()
    {

        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        


            if (Input.touchCount > 0 && midMove == "n")
            {

                touch = Input.GetTouch(0);


                if (Input.GetMouseButtonDown(0))
                {
                    print("gege");
                isCharging = true;
                StartCoroutine("SlowTimeDelay");
                
            }

                if (Input.GetMouseButton(0) && mouseDrag == true)

                {
                    print("moved");
                    OnMouseDrag();
                    mouseDrag = false;
                   // canSlow = false;
                    // Time.timeScale = 1f;


                }

                if (Input.GetMouseButtonUp(0))
                {
                isCharging = false;
                    print("ended");
                StopCoroutine("SlowTimeDelay");
                StopCoroutine("StartCounting");
                    Time.timeScale = 1f;
                rend.material.color = Color.white;
                
                // canSlow = false;
                if (holdingTime == zero)
                    {
                        return;
                    
                }

                    if (holdingTime < 0.05f)
                    {

                    /* previousDistanceToTouchPos = zero;
                     currentDistanceToTouchPos = zero;
                     isMoving = true;

                     touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                     touchPosition.z = zero;
                     whereToMove = (touchPosition - transform.position).normalized;
                     rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed); */
                    //print(moveSpeed); 
                    return;
                    
                }


                    if (holdingTime < 0.1f && (holdingTime > 0.055f))
                    {

                    level1Move = true;

                    }
                    if (holdingTime < 0.3f && (holdingTime > 0.1f))
                    {

                    level2Move = true;

                    }
                    if (holdingTime > 0.3f && (holdingTime > 0.15f))
                    {

                    level3Move = true;

                }
                    velocity = rb.velocity.magnitude;

                    previous = transform.position;
                    midMove = "y";
                    // GameObject enableMoves = GameObject.Find("Hazards");
                    //enableMoves.GetComponent<AutoMove>().isAllowedToMove = false;
                    // FindObjectOfType<GameManager>().TapRelease();
                }
            }

            /*
            if (Input.touchCount > 0 && midMove == "n")
            {

                touch = Input.GetTouch(0);


                if (touch.phase == TouchPhase.Began)
                {


                    print("gege");
                        StartCoroutine("StartCounting");



                        //GameObject Hazards = GameObject.FindWithTag("hazard");
                        //Hazards.GetComponent<AutoMove>().isAllowedToMove = false;
                        //  isTouching = true;
                        // print("gege");
                        // StartCoroutine("StartCounting");








                }


             //    if (Input.GetTouch(0).phase == TouchPhase.Stationary && drag.isDragging == false)
            //   {
                    //FindObjectOfType<GameManager>().LevelHasEnded();
             //       StartCoroutine("StartCounting");
             //   }
                 if (Input.GetTouch(0).phase == TouchPhase.Moved)
                  {
                      //print("moved");
                    StopCoroutine("StartCounting");
                      holdingTime = zero;


                }

                  if (Input.GetTouch(0).phase == TouchPhase.Ended)
                  {

                     // print("ended");
                      StopCoroutine("StartCounting");
                    if (holdingTime == zero)
                    {
                        return;
                    }

                    if (holdingTime < 0.5f)
                       {

                            previousDistanceToTouchPos = zero;
                            currentDistanceToTouchPos = zero;
                            isMoving = true;

                            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                            touchPosition.z = zero;
                            whereToMove = (touchPosition - transform.position).normalized;
                            rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
                            //print(moveSpeed); 




                       } 


                       if (holdingTime < 1f && (holdingTime > 0.55f))
                       {
                           previousDistanceToTouchPos = 0;
                           currentDistanceToTouchPos = 0;
                           isMoving = true;

                           touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                           touchPosition.z = 0;
                           whereToMove = (touchPosition - transform.position).normalized;
                           //offset = touchPosition - transform.position;
                           rb.velocity = new Vector2(whereToMove.x * 15, whereToMove.y * 15);
                           print(10);

                           //  GameObject enableMove = GameObject.FindWithTag("hazard");
                           //  enableMove.GetComponent<AutoMove>().isAllowedToMove = false;
                       }
                       if (holdingTime < 3f && (holdingTime > 1f)) 
                       {
                           previousDistanceToTouchPos = 0;
                           currentDistanceToTouchPos = 0;
                           isMoving = true;

                           touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                           touchPosition.z = 0;
                           whereToMove = (touchPosition - transform.position).normalized;
                           rb.velocity = new Vector2(whereToMove.x * 28, whereToMove.y * 28);

                           print(28);

                           // GameObject Hazards = GameObject.FindWithTag("hazard");
                           // Hazards.GetComponent<AutoMove>().isAllowedToMove = false;
                       }
                       if (holdingTime > 3f && (holdingTime > 1.5f))
                       {
                           previousDistanceToTouchPos = 0;
                           currentDistanceToTouchPos = 0;
                           isMoving = true;

                           touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                           touchPosition.z = 0;
                           whereToMove = (touchPosition - transform.position).normalized;
                           rb.velocity = new Vector2(whereToMove.x * 50, whereToMove.y * 50);
                           print(50);

                           //  GameObject Hazards = GameObject.FindWithTag("hazard");
                           //  Hazards.GetComponent<AutoMove>().isAllowedToMove = false;

                       }





                   //print(rb.velocity);
                   //print(velocity + "fgndsjkfnsdj");
                   velocity = rb.velocity.magnitude;

                  //((transform.position - previous).magnitude) / Time.deltaTime;
                   previous = transform.position;
                   midMove = "y";
                    // isTouching = false;

                    // print(midMove + "fdjsfndk");

                    // GameObject enableMoves = GameObject.Find("Hazards");
                    //enableMoves.GetComponent<AutoMove>().isAllowedToMove = false;
                   // FindObjectOfType<GameManager>().TapRelease();
                }


           } 

            */

            if (currentDistanceToTouchPos > previousDistanceToTouchPos)
            {
                isMoving = false;
                rb.velocity = Vector2.zero;
            
                midMove = "n";
            


            }
   




        if (isMoving)
                previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;




        }

    

    void FixedUpdate()
    {
        executeMove();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        /*
        if (col.gameObject.tag == "breakableWall" && velocity < 11f)
        {

            FindObjectOfType<GameManager>().GameOver();
            rb.velocity = Vector2.zero;
        }

        else if (col.gameObject.tag == "breakableWall" && velocity > 11f && drag.isDragging == false)
        {
           // rb.velocity = Vector2.zero;
            Destroy(col.gameObject);
        } */


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "breakableWall" && velocity < 11f)
        {

            FindObjectOfType<GameManager>().GameOver();
            rb.velocity = Vector2.zero;
        }

        else if (col.gameObject.tag == "breakableWall" && velocity > 11f && drag.isDragging == false)
        {
            // rb.velocity = Vector2.zero;
            Destroy(col.gameObject);
        }


    }


    IEnumerator StartCounting()
    {
        for (holdingTime = 0f; holdingTime <= 4f; holdingTime += Time.deltaTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            if (holdingTime < 0.1f && (holdingTime > 0.055f))
            {
                rend.material.color = Color.green;
            }
            if (holdingTime < 0.3f && (holdingTime > 0.1f))
            {
                rend.material.color = Color.blue;
            }
            if (holdingTime > 0.3f && (holdingTime > 0.15f))
            {
                rend.material.color = Color.red;
            }

            
            

        }
       

    }

    IEnumerator SlowTimeDelay()
    {
        if (isCharging == true)
        {
            
            yield return new WaitForSeconds(0.2f);
            StartCoroutine("StartCounting");
            slowTime();
        }
                
            
            
        
            
    }


    public void GameOverVelocityZero()
    {
        if (gameManager.gameHasEnded == true)
        {
            rb.velocity = Vector2.zero;

        }
    }

    void OnMouseDrag()
    {
        StopCoroutine("StartCounting");
        holdingTime = zero;
        mouseDrag = true;
        
    }

    void slowTime()
    {
        Time.timeScale = 0.1f;
        //slowing = true;
    }


    void executeMove()
    {
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        if (level1Move == true)
        {
            previousDistanceToTouchPos = 0;
            currentDistanceToTouchPos = 0;
            isMoving = true;

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            whereToMove = (touchPosition - transform.position).normalized;
            
            rb.velocity = new Vector2(whereToMove.x  * 10, whereToMove.y * 10);

            CameraShaker.Instance.ShakeOnce(4f, 1f, 0.1f, 1f);
            Instantiate(TapChargeParticle, transform.position, Quaternion.identity);
            level1Move = false;

            holdingTime = 0f;
        }

        if (level2Move == true)
        {
            previousDistanceToTouchPos = 0;
            currentDistanceToTouchPos = 0;
            isMoving = true;

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            whereToMove = (touchPosition - transform.position).normalized;
            rb.velocity = new Vector2(whereToMove.x * 15, whereToMove.y * 15);

            CameraShaker.Instance.ShakeOnce(4f, 1f, 0.1f, 1f);
            Instantiate(TapChargeParticle, transform.position, Quaternion.identity);
            level2Move = false;

            holdingTime = 0f;
        }

        if (level3Move == true)
        {
            previousDistanceToTouchPos = 0;
            currentDistanceToTouchPos = 0;
            isMoving = true;

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            whereToMove = (touchPosition - transform.position).normalized;
            rb.velocity = new Vector2(whereToMove.x * 25, whereToMove.y * 25);

            CameraShaker.Instance.ShakeOnce(4f, 1f, 0.1f, 1f);
            Instantiate(TapChargeParticle, transform.position, Quaternion.identity);
            level3Move = false;

            holdingTime = 0f;
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;

            midMove = "n";
        }


        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        velocity = rb.velocity.magnitude;

    }
    
}

    





