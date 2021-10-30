using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPackage
{

    public string inputString;
    public string[] inputArray;
    public int inputInstance = 1;
    public int maxIteration = 16;
    public int lifeTime = 31;

    // string inputStr must be have spaces between inputs
    // example: "5 J"
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
    
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    } 
    
    public bool Equals (InputPackage? other)
    {
        return this.inputString.Equals(other.inputString);
    }
    
    /*public static bool operator==(InputPackage me, InputPackage other)
    {
        return me.inputString.Equals(other.inputString);
    }

    public static bool operator !=(InputPackage me, InputPackage other)
    {
        return !(me == other);
    }*/

}
