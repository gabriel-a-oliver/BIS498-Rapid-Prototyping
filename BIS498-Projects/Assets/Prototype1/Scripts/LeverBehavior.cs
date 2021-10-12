using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehavior : MonoBehaviour
{
    public bool upwardState = true;
    public bool downwardState = false;
    public bool currentlyFlipping = false;
    [SerializeField] private float flippingLerpDuration = 1f;
    public GameObject leverNeck;
    public AudioClip flippedUpSound;
    public AudioClip flippedDownSound;
    private void OnEnable()
    {
        EventManagerBehavior.flippingDown += FlippingDown;
        EventManagerBehavior.flippingUp += FlippingUp;
        EventManagerBehavior.flippedDown += FlippedDown;
        EventManagerBehavior.flippedUp += FlippedUp;
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
        EventManagerBehavior.flippedDown -= FlippedDown;
        EventManagerBehavior.flippedUp -= FlippedUp;
    }
    private void FlippingDown()
    {
        downwardState = true;
        upwardState = false;
        Quaternion newRotation = Quaternion.Euler(-135f, 0f, 0f);
        StartCoroutine(RotateLeverNeck(newRotation, flippingLerpDuration, true));
    }
    private void FlippingUp()
    {
        downwardState = false;
        upwardState = true;
        Quaternion newRotation = Quaternion.Euler(-45f, 0f, 0f);
        StartCoroutine(RotateLeverNeck(newRotation, flippingLerpDuration, false));
    }

    // Help From: https://answers.unity.com/questions/192438/coroutines-and-lerp-how-to-make-them-friends.html
    // NOTE: lerpDuration CANNOT be less than or equal to 0
    private IEnumerator RotateLeverNeck(Quaternion newRotation, float lerpDuration, bool flippingDown)
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
            leverNeck.transform.rotation = Quaternion.Slerp(originalRotation, newRotation, 
                    Mathf.SmoothStep(0, 1, currentTime / lerpDuration));
            currentTime += Time.deltaTime;
            yield return null;
        }
        leverNeck.transform.rotation = Quaternion.Slerp(originalRotation, newRotation, 1f);
        currentlyFlipping = false;
        if (flippingDown)
        {
            EventManagerBehavior.FlippedDownBehaviors();
        }
        else
        {
            EventManagerBehavior.FlippedUpBehaviors();
        }
    }

    private void FlippedDown()
    {
        Debug.Log("Now Down State");
        AudioSource.PlayClipAtPoint(flippedDownSound, Vector3.zero);
    }
    private void FlippedUp()
    {
        Debug.Log("Now Up State");
        AudioSource.PlayClipAtPoint(flippedUpSound, Vector3.zero);
    }
}
