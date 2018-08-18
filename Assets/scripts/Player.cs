using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour {

    /* public delegate void PlayerDelegate();
     public static event PlayerDelegate OnPlayerDied;
     public Vector3 startPos;
     GameManager game;
     Rigidbody2D rb;





     void Start() {
         rigidbody = GetComponent<Rigidbody2D>();
         game = GameManager.Instance;
         //GetComponent<Rigidbody>().simulated = false;

     }


     void Update() {
         if (game.GameOver) return;



     }




     void OnTriggerEnter2D(Collider2D col)
     {
         if (col.gameObject.name == "Projectile")
         {
             //GetComponent<Rigidbody>().simulated = false;
             OnPlayerDied();
         }
     }

     void OnEnable()
     {
         GameManager.OnGameStarted += OnGameStarted;
         GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
     }

     void OnDisable()
     {
         GameManager.OnGameStarted -= OnGameStarted;
         GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
     }

     void OnGameStarted()
     {
         //GetComponent<Rigidbody>().velocity = Vector3.zero;
         // GetComponent<Rigidbody>().simulated = true;
         print("Start");
     }

     void OnGameOverConfirmed()
     {
         transform.localPosition = startPos;
         //transform.rotation = Quaternion.identity;
     } */


    public string levelToLoad;
   

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "breakableWall")
        {
            
            return;
           
        }
        if (col.gameObject.name == "Projectile")
        {
            
         
            FindObjectOfType<GameManager>().GameOver();
        }

        if (col.gameObject.tag == "harmless")
        {
            return;
            
        }

        else
        {
            
            FindObjectOfType<GameManager>().GameOver();
            GameObject disableVelo = GameObject.FindWithTag("player");
            disableVelo.GetComponentInParent<HoldMove>().GameOverVelocityZero();

            //Application.LoadLevel(levelToLoad);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "projectile")
        {
            FindObjectOfType<GameManager>().GameOver();
            GameObject enableMoves = GameObject.FindWithTag("hazard");
            enableMoves.GetComponentInParent<AutoMove>().isAllowedToMove = false;
            GameObject enableDrag = GameObject.FindWithTag("player");
            enableDrag.GetComponentInParent<Drag>().canDrag = false;
            GameObject disableVelo = GameObject.FindWithTag("player");
            disableVelo.GetComponentInParent<HoldMove>().GameOverVelocityZero();
            
            
        }

        if (col.gameObject.name == "FinishLine")
        {
            
            //USING endTrigger script attached 
            FindObjectOfType<GameManager>().CompleteLevel();
        }

        else
        {
            return;
        }
    }
}

