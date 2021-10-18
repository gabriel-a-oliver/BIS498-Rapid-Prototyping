using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = System.Random;

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

    [SerializeField] private GameObject sideLight;
    [SerializeField] private GameObject topLight;
    
    
    [SerializeField] private GameObject topSparkLight;
    [SerializeField] private GameObject topSparks;
    
    [SerializeField] private GameObject bottomSparkLight;
    [SerializeField] private GameObject bottonSparks;


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
                sideLight.GetComponent<Light>().intensity = Mathf.Lerp(0.8f, 0, currentTime / lerpDuration);
                topLight.GetComponent<Light>().intensity = Mathf.Lerp(0, 0.35f, currentTime / lerpDuration);
                if ((currentTime / lerpDuration) > 1/5f)
                {
                    light1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 1f));
                }
                if ((currentTime / lerpDuration) > 2/5f)
                {
                    light2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 1f));
                }
                if ((currentTime / lerpDuration) > 3/5f)
                {
                    light3.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 1f));
                }
                if ((currentTime / lerpDuration) > 4/5f)
                {
                    light4.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 1f));
                }
            }
            else
            {
                handleRenderer.material.color = Color.Lerp(Color.red, Color.blue, currentTime / lerpDuration);
                sideLight.GetComponent<Light>().intensity = Mathf.Lerp(0, 0.8f, currentTime / lerpDuration);
                topLight.GetComponent<Light>().intensity = Mathf.Lerp(0.35f, 0, currentTime / lerpDuration);
                if ((currentTime / lerpDuration) > 1/5f)
                {
                    light5.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 0f));
                }
                if ((currentTime / lerpDuration) > 2/5f)
                {
                    light4.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 0f));
                }
                if ((currentTime / lerpDuration) > 3/5f)
                {
                    light3.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 0f));
                }
                if ((currentTime / lerpDuration) > 4/5f)
                {
                    light2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 0f));
                }
            }
            currentTime += Time.deltaTime;
            yield return null;
        }
        leverNeck.transform.rotation = Quaternion.Slerp(originalRotation, newRotation, 1f);
        currentlyFlipping = false;
        if (flippingDown)
        {
            sideLight.GetComponent<Light>().intensity = Mathf.Lerp(0, 0.8f, 0);
            topLight.GetComponent<Light>().intensity = Mathf.Lerp(0.35f, 0, 0);
            handleRenderer.material.color = Color.Lerp(Color.blue, Color.red, 1f);
            light5.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 1f));
            EventManagerBehavior.FlippedDownBehaviors();
        }
        else
        {
            sideLight.GetComponent<Light>().intensity = Mathf.Lerp(0, 0.8f, 1);
            topLight.GetComponent<Light>().intensity = Mathf.Lerp(0.35f, 0, 1);
            handleRenderer.material.color = Color.Lerp(Color.blue, Color.red, 0f);
            light1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.red, 0f));
            EventManagerBehavior.FlippedUpBehaviors();
        }
    }
    
    private void FlippedDown()
    {
        downwardState = true;
        Debug.Log("Now Down State");

        StartCoroutine(ActivateSparks(bottonSparks, bottomSparkLight));
        AudioSource.PlayClipAtPoint(flippedDownSound, Vector3.zero);
    }
    private void FlippedUp()
    {
        upwardState = true;
        Debug.Log("Now Up State");
        
        StartCoroutine(ActivateSparks(topSparks, topSparkLight));
        AudioSource.PlayClipAtPoint(flippedUpSound, Vector3.zero);
    }

    private IEnumerator ActivateSparks(GameObject sparks, GameObject sparksLight)
    {
        if (UnityEngine.Random.Range(0f, 3f) >= 2)
        {
            float currentTime = 0f;
            const float SPARKLIFE = 0.25f;
    
            while (currentTime <= SPARKLIFE)
            {
                sparks.gameObject.SetActive(true);
                sparksLight.gameObject.SetActive(true);
                currentTime += Time.deltaTime;
                yield return null;
            }
            sparks.gameObject.SetActive(false);
            sparksLight.gameObject.SetActive(false);
        }
    }
}
