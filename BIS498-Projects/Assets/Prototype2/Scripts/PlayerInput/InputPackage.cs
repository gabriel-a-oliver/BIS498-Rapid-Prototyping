using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPackage
{

    public string inputString;
    public string[] inputArray;
    public int inputInstance = 1;
    public int maxIteration = 11;
    public int lifeTime = 31;

    public InputPackage(string inputStr)
    {
        // Help from: https://answers.unity.com/questions/672553/how-to-split-a-string-into-array.html
        inputString = inputStr;
        inputArray = inputString.Split(" "[0]);
        
        /*string testOutput = "";
        for(int i = 0; i < inputArray.Length; i++){
            testOutput += (inputArray[i]); //each split
        }
        Debug.Log(testOutput);*/
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
