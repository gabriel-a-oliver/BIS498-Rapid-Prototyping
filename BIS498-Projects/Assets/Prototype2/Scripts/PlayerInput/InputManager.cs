using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputPackage[] _inputPackages;
    [SerializeField] private String currentInput = "";
    [SerializeField] private String previousInput = "";
    [SerializeField] private int maxInstances = 10;

    public BasicAction InterpretCurrentInput(String currentInput)
    {

        if (InputPackagesArrayIsEmpty() || (!previousInput.Equals(_inputPackages[0].inputString) || _inputPackages[0].inputInstance == maxInstances))
        {
            InputPackage newPackage = new InputPackage();
            newPackage.inputString = currentInput;
            String[] inputArray = currentInput.Split();
            newPackage.inputArray = inputArray;
            this.InsertInputPackageToArray(newPackage);

            if (inputArray[0].Equals("P") || inputArray[0].Equals("J"))
            {
                Debug.Log("Button Detected");
            }
        }
        else
        {
            _inputPackages[0].inputInstance++;
        }
        
        
        
        
        /*for ()
        {
            
        }*/
        
        return null;
    }

    // help from: https://stackoverflow.com/questions/21385066/shifting-array-elements-to-right
    private void InsertInputPackageToArray(InputPackage currentPackage)
    {
        _inputPackages[_inputPackages.Length - 1] = null;

        InputPackage[] newPackagesArray = new InputPackage[_inputPackages.Length];
        
        for (int i = 1; i < _inputPackages.Length; i++)
        {
            newPackagesArray[i] = _inputPackages[i - 1];
        }

        newPackagesArray[0] = currentPackage;
        _inputPackages = newPackagesArray;
    }


    private void Awake()
    {
        _inputPackages = new InputPackage[100];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool InputPackagesArrayIsEmpty()
    {
        /*if (_inputPackages == null || _inputPackages.Length == 0)
        {
            return true;
        }*/
        
        for (int i = 0; i < _inputPackages.Length; i++)
        {
            if (_inputPackages[i] != null)
            {
                return false;
            }
        }

        return true;
    }
}
