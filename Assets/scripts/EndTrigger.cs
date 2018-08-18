using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == ("Player"))
        {
            
            gameManager.CompleteLevel();
        }
        
    }
}
