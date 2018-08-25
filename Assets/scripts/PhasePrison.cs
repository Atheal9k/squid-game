using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasePrison : MonoBehaviour {

    public float startDelay = 0.5f;
   // public float repeatRate = 2f;
    private bool whichTag = true;
    private Color originalColor;
    Collider2D collider;
    private Animator anim;
    //public PhasePrison phasePrison;
    public bool canPhase = false;


    void Start()
    {
        
        collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("tagChange");
    }

    IEnumerator tagChange()
    {
        print("fefsefs");
        
            
            if (canPhase == true)
            {
            print("true");
            transform.gameObject.tag = "harmless";
                anim.SetBool("harmless", true);
                collider.enabled = false;
                whichTag = true;




                yield return new WaitForSeconds(startDelay);
                if (whichTag == true)
                {
                    transform.gameObject.tag = "Untagged";
                    anim.SetBool("harmless", false);
                    collider.enabled = true;
                    whichTag = false;
                }

            

        }




    }


   


}
