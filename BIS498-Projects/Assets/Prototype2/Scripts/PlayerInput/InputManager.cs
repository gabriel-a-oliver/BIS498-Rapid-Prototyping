using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputPackage[] _inputPackages;
    [SerializeField] private String previousInput = "";

    public InputPackage[] InterpretCurrentInput(String currentInput)
    {
        InputPackage[] result = null;
        
        if ((!previousInput.Equals(currentInput)) || ((_inputPackages[0].inputInstance >= _inputPackages[0].maxIteration)))
        {
            InputPackage newInputPackage = CreateInputPackage(currentInput);
            result = CreateLongestPossibleInput(newInputPackage);
        }
        else
        {
            _inputPackages[0].inputInstance++;
        }
        //DisplayInputArray();
        
        return result;
    }

    private void DisplayInputArray()
    {
        if (_inputPackages[0] != null)
        {
            string resultPrint = "";
            for (int i = 0; i < _inputPackages.Length; i++)
            {
                if (_inputPackages[i] != null)
                {
                    resultPrint += _inputPackages[i].inputString + "-" + _inputPackages[i].inputInstance + ", ";
                }
            }
            Debug.Log(resultPrint);
        }
    }

    private void DisplayActionInput(InputPackage[] actionInput)
    {
        string resultPrint = "";
        for (int i = 0; i < actionInput.Length; i++)
        {
            if (actionInput[i] != null)
            {
                resultPrint += actionInput[i].inputString + "-" + actionInput[i].inputInstance + ", ";
            }
        }
        Debug.Log(resultPrint);
    }

    private InputPackage[] CreateLongestPossibleInput(InputPackage currentInputPackage)
    {
        InputPackage[] result = null;
        if (currentInputPackage.inputString.Contains("P") || currentInputPackage.inputString.Contains("J"))
        {
            InputPackage[] longestPossibleInput = new InputPackage[7];
            longestPossibleInput[0] = currentInputPackage;
            for (int i = 1; i < longestPossibleInput.Length - 1; i++)
            {
                longestPossibleInput[i] = _inputPackages[i];
            }
            DisplayActionInput(longestPossibleInput);
            result = longestPossibleInput;
        }
        return result;
    }

    private InputPackage CreateInputPackage(string currentInput)
    {
        InputPackage newInputPackage = new InputPackage(currentInput);
        this.InsertInputPackageToArray(newInputPackage);
        this.previousInput = currentInput;
        return newInputPackage;
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
        _inputPackages = new InputPackage[100]; // Equivalent to 100 frames or 1.4 seconds
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
