using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Proto3EventHandlerBehavior : MonoBehaviour
{
    [SerializeField] private DialogueManagerBehavior dmb;
    
    [SerializeField] private int fpsTarget = 60;
    [SerializeField] private TMP_Text fpsText;
    [SerializeField] private float deltaTime;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fpsTarget;
        checkFPS();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showFPS();
        
        
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
