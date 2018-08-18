using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{


    // public bool isAllowedToTrigger = false;
    public string levelToLoad;

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
