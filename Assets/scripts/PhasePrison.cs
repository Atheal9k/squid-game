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
        
    }

    IEnumerator tagChange()
    {
        if (canPhase == true)
        {
           if (gameObject.name == "bottonphaseBlock")
            {
                GameObject.Find("bottomphaseBlock").transform.gameObject.tag = "harmless";
                anim.SetBool("harmless", false);
                yield return new WaitForSeconds(1f);
            }
            
        }
       
        



    }

   public void phase()
    {
        StartCoroutine("tagChange");
    }


}
