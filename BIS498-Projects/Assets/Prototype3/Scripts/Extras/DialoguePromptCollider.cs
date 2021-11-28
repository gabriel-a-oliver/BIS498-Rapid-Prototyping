using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class DialoguePromptCollider : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            textComponent.transform.parent.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        textComponent.transform.parent.gameObject.SetActive(false);
    }
}
