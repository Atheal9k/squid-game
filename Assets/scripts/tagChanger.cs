using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagChanger : MonoBehaviour {

    public float startDelay = 0.5f;
    public float repeatRate = 2f;
    private bool whichTag = true;
    private Color originalColor;
    Collider2D collider;
    private Animator anim;
    //public PhasePrison phasePrison;


    void Start () {

       
            InvokeRepeating("tagChange", startDelay, repeatRate);
            collider = GetComponent<Collider2D>();
            anim = GetComponent<Animator>();
       
       
        
    }
	
	void tagChange()
    {
       
            if (whichTag == true)
            {
                transform.gameObject.tag = "Untagged";
                anim.SetBool("harmless", false);
                collider.enabled = true;
                whichTag = false;
            }
            else
            {
                transform.gameObject.tag = "harmless";
                anim.SetBool("harmless", true);
                collider.enabled = false;
                whichTag = true;
            }
        

        
    }
}
