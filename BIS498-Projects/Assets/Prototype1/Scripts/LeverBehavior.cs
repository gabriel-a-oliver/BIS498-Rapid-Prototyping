using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehavior : MonoBehaviour
{
    public bool upwardState = true;
    public bool downwardState = false;
    public GameObject leverNeck;
    private void OnEnable()
    {
        EventManagerBehavior.flippingDown += FlippingDown;
        EventManagerBehavior.flippingUp += FlippingUp;
    }
    void Start()
    {
        upwardState = true;
        downwardState = false;
    }
    private void OnDisable()
    {
        EventManagerBehavior.flippingDown -= FlippingDown;
        EventManagerBehavior.flippingUp -= FlippingUp;
    }
    private void FlippingDown()
    {
        downwardState = true;
        upwardState = false;
        leverNeck.transform.Rotate(Vector3.right, -90f);
        Debug.Log("Now Down State");
    }
    private void FlippingUp()
    {
        downwardState = false;
        upwardState = true;
        leverNeck.transform.Rotate(Vector3.right, 90f);
        Debug.Log("Now Up State");
    }
}
