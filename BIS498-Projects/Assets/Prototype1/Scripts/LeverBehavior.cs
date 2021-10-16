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
    public AudioClip flippingUpSound;
    public AudioClip flippingDownSound;


    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;
    [SerializeField] private GameObject light4;
    [SerializeField] private GameObject light5;
    
    
    private void OnEnable()
    {
        EventManagerBehavior.flippingDown += FlippingDown;
        EventManagerBehavior.flippingUp += FlippingUp;
        EventManagerBehavior.flippedDown += FlippedDown;
        EventManagerBehavior.flippedUp += FlippedUp;
        EventManagerBehavior.flipDownStart += FlipDownStart;
        EventManagerBehavior.flipUpStart += FlipUpStart;
    }
    private void OnDisable()
        {
            EventManagerBehavior.flippingDown -= FlippingDown;
            EventManagerBehavior.flippingUp -= FlippingUp;
            EventManagerBehavior.flippedDown -= FlippedDown;
            EventManagerBehavior.flippedUp -= FlippedUp;
            EventManagerBehavior.flipDownStart -= FlipDownStart;
            EventManagerBehavior.flipUpStart -= FlipUpStart;
    }
    void Start()
    {
        upwardState = true;
        downwardState = false;
        currentlyFlipping = false;
    }
    
    private void FlipDownStart()
    {
        upwardState = false;
        AudioSource.PlayClipAtPoint(flippingDownSound, Vector3.zero);
        EventManagerBehavior.FlippingDownBehaviors();
    }

    private void FlipUpStart()
    {
        downwardState = false;
        AudioSource.PlayClipAtPoint(flippingUpSound, Vector3.zero);
        EventManagerBehavior.FlippingUpBehaviors();
    }
    
    private void FlippingDown()
    {
        Quaternion newRotation = Quaternion.Euler(-135f, 0f, 0f);
        StartCoroutine(RotateLeverNeck(newRotation, flippingLerpDuration, true));
    }
    private void FlippingUp()
    {
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
        Renderer handleRenderer = leverNeck.transform.GetChild(0).GetComponent<Renderer>();
        while (currentTime <= lerpDuration)
        {
            leverNeck.transform.rotation = Quaternion.Slerp(originalRotation, newRotation, 
                    Mathf.SmoothStep(0, 1, currentTime / lerpDuration));
            if (flippingDown)
            {
                handleRenderer.material.color = Color.Lerp(Color.blue, Color.red, currentTime / lerpDuration);
                if ((currentTime / lerpDuration) > 1/5f)
                {
                    light1.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 1f);
                }
                if ((currentTime / lerpDuration) > 2/5f)
                {
                    light2.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 1f);
                }
                if ((currentTime / lerpDuration) > 3/5f)
                {
                    light3.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 1f);
                }
                if ((currentTime / lerpDuration) > 4/5f)
                {
                    light4.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 1f);
                }
            }
            else
            {
                handleRenderer.material.color = Color.Lerp(Color.red, Color.blue, currentTime / lerpDuration);
                if ((currentTime / lerpDuration) > 1/5f)
                {
                    light5.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 0f);
                }
                if ((currentTime / lerpDuration) > 2/5f)
                {
                    light4.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 0f);
                }
                if ((currentTime / lerpDuration) > 3/5f)
                {
                    light3.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 0f);
                }
                if ((currentTime / lerpDuration) > 4/5f)
                {
                    light2.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 0f);
                }
            }
            currentTime += Time.deltaTime;
            yield return null;
        }
        leverNeck.transform.rotation = Quaternion.Slerp(originalRotation, newRotation, 1f);
        currentlyFlipping = false;
        if (flippingDown)
        {
            handleRenderer.material.color = Color.Lerp(Color.blue, Color.red, 1f);
            light5.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 1f);
            EventManagerBehavior.FlippedDownBehaviors();
        }
        else
        {
            handleRenderer.material.color = Color.Lerp(Color.blue, Color.red, 0f);
            light1.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 0f);
            EventManagerBehavior.FlippedUpBehaviors();
        }
    }
    
    private void FlippedDown()
    {
        downwardState = true;
        Debug.Log("Now Down State");

        //light1.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 1f);
        
        AudioSource.PlayClipAtPoint(flippedDownSound, Vector3.zero);
    }
    private void FlippedUp()
    {
        upwardState = true;
        Debug.Log("Now Up State");
        
        //light1.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 0f);
        
        AudioSource.PlayClipAtPoint(flippedUpSound, Vector3.zero);
    }
}
