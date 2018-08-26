using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingEnemy : MonoBehaviour
    {

        [SerializeField]
        GameObject projectile;
        

        public float speed = 5f;
        float fireRate;
        float nextFire;
    private Animator anim;
    bool canSeePlayer = false;
    
    //public GameObject cannonFire;
    public Transform bulletOffset;
  
    

   


        void Start()
        {
        
            fireRate = 8f;
            nextFire = Time.time;
        anim = GetComponent<Animator>();
        //target = GameObject.Find("bulletOffsets");


    }


        void Update()
        {

       // anim.SetBool("fire", false);
        CheckIfTimeToFire();
     
        
            
        }

        void CheckIfTimeToFire()
        {
       
        if (Time.time > nextFire)
            {
            
               
                Instantiate(projectile, bulletOffset.transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            
           
            }
        }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnBecameVisible()
    {
        canSeePlayer = true;
    }

    public void cannonFire()
    {
       // anim.PlayInFixedTime("cannonFire", -1, 10.0f);
    }

    
   

}
