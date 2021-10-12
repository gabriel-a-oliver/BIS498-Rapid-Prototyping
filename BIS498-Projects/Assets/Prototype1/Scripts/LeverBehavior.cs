using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehavior : MonoBehaviour
{
    public bool upwardState = true;
    public bool downwardState = false;
    public bool currentlyFlipping = false;
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
        Quaternion newRotation = Quaternion.Euler(-135f, 0f, 0f);
        StartCoroutine(RotateLeverNeck(newRotation, 2f));
        //leverNeck.transform.Rotate(Vector3.right, -90f);
        Debug.Log("Now Down State");
    }
    private void FlippingUp()
    {
        downwardState = false;
        upwardState = true;
        Quaternion newRotation = Quaternion.Euler(-45f, 0f, 0f);
        StartCoroutine(RotateLeverNeck(newRotation, 2f));
        //leverNeck.transform.Rotate(Vector3.right, 90f);
        Debug.Log("Now Up State");
    }

    // Help From: https://answers.unity.com/questions/192438/coroutines-and-lerp-how-to-make-them-friends.html
    // NOTE: lerpDuration CANNOT be less than or equal to 0
    private IEnumerator RotateLeverNeck(Quaternion newRotation, float lerpDuration)
    {
        currentlyFlipping = true;
        if (lerpDuration <= 0f)
        {
            Debug.LogError("lerpDuration Cannot be less than or equal to 0");
            yield return null;
        }
        float currentTime = 0f;
        Quaternion originalRotation = leverNeck.transform.rotation;
        while (currentTime <= lerpDuration)
        {
            leverNeck.transform.rotation = Quaternion.Slerp(originalRotation, newRotation, currentTime / lerpDuration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        leverNeck.transform.rotation = Quaternion.Slerp(originalRotation, newRotation, 1f);
        currentlyFlipping = false;
    }
}
