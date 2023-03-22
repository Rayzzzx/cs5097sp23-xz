using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mapbox library
using Mapbox.Examples;
using Mapbox.Utils;

public class EventPointer : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;

    [SerializeField] private float amplitude = 2.0f;

    [SerializeField] private float frequency = 0.50f;

    private LocationStatus playerLocation;

    public Vector2d eventPose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotatePointer();
    }

    // Function that make the pointer float and rotate.
    void FloatAndRotatePointer()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x,
            (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + 15, transform.position.z);
    }

    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        Debug.Log("Clicked.");
    }
}
