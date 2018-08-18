using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    float moveSpeed = 2f;

    Rigidbody2D rb;

    Player target;

    Vector2 moveDirection;
	
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 12f);
	}
	
	
   

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == ("Player") || col.gameObject.name == ("BreakableWall"))
        {
            Destroy(gameObject);
        }
	}
}
