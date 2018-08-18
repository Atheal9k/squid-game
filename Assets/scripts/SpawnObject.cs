using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject[] colliders;
    public Vector3 waypoint;

    // Use this for initialization
    void Start()
    {
        colliders = GameObject.FindGameObjectsWithTag("collider");
    }

    // Update is called once per frame
    void Update()
    {
        waypoint = this.gameObject.transform.position;
        CheckNewWaypoint();

    }

    void CheckNewWaypoint()
    {
        foreach (GameObject collider in colliders)
        {
            Renderer renderer = collider.GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;
            if (bounds.Contains(waypoint))
            {
                Debug.Log("IM INSIDE SOMETHING");
            }
        }
    }
}
