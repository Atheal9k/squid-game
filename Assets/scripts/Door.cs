using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {


   // public bool isAllowedToTrigger = false;
    public int levelToLoad;

    void Start()
    {
        //GameObject enableDoor = GameObject.Find("door");
        //enableDoor.GetComponent<Door>().enabled = false;
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
       // if (isAllowedToTrigger)
        {
            Application.LoadLevel(levelToLoad);
        }
            
    }
}
