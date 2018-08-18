using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour {

    Rigidbody2D rb;

    Player player;

    void Start()
    {
        //speedOfPlayer = GameObject.GetComponent<player>();
        //player = player.GetComponent<player>();
        rb = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "BreakableWall")
        {
            Destroy(col.gameObject);
        }
    }
}
