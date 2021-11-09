using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputPackage[] _inputPackages;
    [SerializeField] private String previousInput = "";

    [SerializeField] private GameObject[] inputStreamArray;
    [SerializeField] private int currentInputStream = 0;
    public GameObject inputStream0;
    public GameObject inputStream1;
    public GameObject inputStream2;
    public GameObject inputStream3;
    public GameObject inputStream4;
    public GameObject inputStream5;
    public GameObject inputStream6;
    public GameObject inputStream7;

    public GameObject direction1;
    public GameObject direction2;
    public GameObject direction3;
    public GameObject direction4;
    public GameObject direction5;
    public GameObject direction6;
    public GameObject direction7;
    public GameObject direction8;
    public GameObject direction9;
    public GameObject buttonA;
    public GameObject buttonB;


    public InputPackage[] InterpretCurrentInput(String currentInput)
    {
        InputPackage[] result = null;
        
        if ((!previousInput.Equals(currentInput)) || ((_inputPackages[0].inputInstance >= _inputPackages[0].maxIteration)))
        {
            InputPackage newInputPackage = CreateInputPackage(currentInput);
            
            DisplayOntoScreen(newInputPackage);
            
            result = CreateLongestPossibleInput(newInputPackage);
        }
        else
        {
            _inputPackages[0].inputInstance++;
        }
        //DisplayInputArray();
        
        return result;
    }

    private void DisplayOntoScreen(InputPackage newInputPackage)
    {
        if (currentInputStream >= 8)
        {
            currentInputStream = 0;
        }

        GameObject currentDirection = null;
        switch (newInputPackage.inputArray[0])
        {
            case "1":
                currentDirection = direction1;
                break;
            case "2":
                currentDirection = direction2;
                break;
            case "3":
                currentDirection = direction3;
                break;
            case "4":
                currentDirection = direction4;
                break;
            case "5":
                currentDirection = direction5;
                break;
            case "6":
                currentDirection = direction6;
                break;
            case "7":
                currentDirection = direction7;
                break;
            case "8":
                currentDirection = direction8;
                break;
            case "9":
                currentDirection = direction9;
                break;
            default:
                Debug.Log("Direction error");
                break;
        }
        
        for (int i = 0; i < inputStreamArray.Length - 1; i++)
        {
            //inputStreamArray[i].
        }
        
        currentInputStream++;
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
                resultPrint += actionInput[i].inputString/* + "-" + actionInput[i].inputInstance*/ + ", ";
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
            //DisplayActionInput(longestPossibleInput);
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
        _inputPackages = new InputPackage[100]; // Equivalent to storing the last 100 frames or 1.4 seconds
        inputStreamArray = new GameObject[8];
        inputStreamArray[0] = inputStream0;
        inputStreamArray[1] = inputStream1;
        inputStreamArray[2] = inputStream2;
        inputStreamArray[3] = inputStream3;
        inputStreamArray[4] = inputStream4;
        inputStreamArray[5] = inputStream5;
        inputStreamArray[6] = inputStream6;
        inputStreamArray[7] = inputStream7;
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
