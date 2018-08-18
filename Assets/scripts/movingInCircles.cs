using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingInCircles : MonoBehaviour {

    public float RotateSpeed = 5f;
    public float Radius = 0.1f;
    private float timeBtwMove;
    public float startTimeBtwMove;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {
        startTimeBtwMove -= Time.deltaTime;
        if (startTimeBtwMove <= 0)
        {
            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;
        }
        
    }
}
