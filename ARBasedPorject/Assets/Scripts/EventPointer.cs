using System;
using System.Collections;
using System.Collections.Generic;
using GeoCoordinatePortable;
using UnityEngine;

// Mapbox library
using Mapbox.Examples;
using Mapbox.Utils;
using UnityEditor;

public class EventPointer : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;

    [SerializeField] private float amplitude = 2.0f;

    [SerializeField] private float frequency = 0.50f;

    private LocationStatus playerLocation;

    public Vector2d eventPos;
    public int eventID;

    private MenuUIManager menuUIManager;
    
    // Start is called before the first frame update
    void Start()
    {
        menuUIManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
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
        var currentPlayerLocation =
            new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLon());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = currentPlayerLocation.GetDistanceTo(eventLocation);
        Debug.Log("Distance is:" + distance);
        if (distance < 100)
        {
            menuUIManager.DisplayStartEventPanel();
        }
        else
        {
            menuUIManager.DisplayUserNotInRangePanel();
        }
    }
}
