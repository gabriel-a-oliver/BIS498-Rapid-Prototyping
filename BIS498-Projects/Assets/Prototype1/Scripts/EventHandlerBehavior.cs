using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventHandlerBehavior : MonoBehaviour
{
    private GameObject lever;
    private GameObject leverHandle;

    [SerializeField] private int fpsTarget = 60;
    [SerializeField] private TMP_Text fpsText;
    [SerializeField] private float deltaTime;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fpsTarget;
    }

    void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");
        leverHandle = GameObject.FindGameObjectWithTag("LeverHandle");
    }

    // Update is called once per frame
    void Update()
    {
        showFPS();
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null && raycastHit.transform.gameObject.CompareTag("LeverHandle")
                                                 && !lever.GetComponent<LeverBehavior>().currentlyFlipping)
                {
                    if (lever.GetComponent<LeverBehavior>().upwardState)
                    {
                        EventManagerBehavior.FlipDownStartBehaviors();
                    }
                    else
                    {
                        EventManagerBehavior.FlipUpStartBehaviors();
                    }
                }
            }
        }
    }

    // help from: https://answers.unity.com/questions/1366716/how-to-liimit-fps.html
    private void checkFPS()
    {
        if (Application.targetFrameRate != fpsTarget)
        {
            Application.targetFrameRate = fpsTarget;
        }
    }
    
    // help from: https://answers.unity.com/questions/1189486/how-to-see-fps-frames-per-second.html
    private void showFPS()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "Frames Per Second: " + Mathf.Ceil (fps).ToString();
    }
}
