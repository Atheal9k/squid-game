using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour {


    //private Transform endGoal;

   

    public float speed = 5;

    Rigidbody2D rb;

    bool endGoalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (endGoalMove == true)
        {
             
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("moveTo").transform.position, step);
        }
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

        if (col.gameObject.tag == "finishLine")
        {

            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("moveTo").transform.position, step);
            
            //USING endTrigger script attached 
            FindObjectOfType<GameManager>().CompleteLevel();
        }

        if (col.gameObject.name == "trig")
        {

            endGoalMove = true;
            
        }

        if (col.gameObject.tag == "phaseTrigger")
        {
            //FindObjectOfType<PhasePrison>().canPhase = true;
            //FindObjectOfType<PhasePrison>().enabled = false;
            
              
            FindObjectOfType<PhasePrison>().canPhase = true;
            FindObjectOfType<PhasePrison>().phase();


        }


        else
        {
            return;
        }
    }
}

