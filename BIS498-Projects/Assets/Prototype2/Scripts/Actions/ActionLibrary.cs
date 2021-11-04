using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLibrary : MonoBehaviour
{
    public List<InputPackage[]> punchInstructions;
    public Dictionary<Tuple<InputPackage[], InputPackage[]>, BasicAction> actionDictionary;

    public struct Tuple<T1, T2> {
        public T1 Item1;
        public T2 Item2;
        public Tuple(T1 item1, T2 item2) { Item1 = item1; Item2 = item2; }
    }

    public static class Tuple { // for type-inference goodness.
        public static Tuple<T1,T2> Create<T1,T2>(T1 item1, T2 item2) { 
            return new Tuple<T1,T2>(item1, item2); 
        }
    }

    private void Awake()
    {
        actionDictionary = new Dictionary<Tuple<InputPackage[], InputPackage[]>, BasicAction>();
        
        // All abilities that use the punch button
        punchInstructions = new List<InputPackage[]>();
        //punchInstructions.Add(new InputPackage[6]{new InputPackage("4"), new InputPackage("1"),new InputPackage("2"), new InputPackage("3"), new InputPackage("6"), new InputPackage("6 P")});
        punchInstructions.Add(new InputPackage[6]{new InputPackage("6 P"), new InputPackage("6"),new InputPackage("3"), new InputPackage("2"), new InputPackage("1"), new InputPackage("4")});
        punchInstructions.Add(new InputPackage[5]{new InputPackage("6 P"), new InputPackage("3"),new InputPackage("2"), new InputPackage("1"), new InputPackage("4")});
        punchInstructions.Add(new InputPackage[4]{new InputPackage("6 P"), new InputPackage("6"), new InputPackage("3"), new InputPackage("2")});
        punchInstructions.Add(new InputPackage[3]{new InputPackage("6 P"), new InputPackage("3"), new InputPackage("2")});
        
        
        
        
        // Fireball dictionary element
        actionDictionary.Add(new Tuple<InputPackage[], InputPackage[]>(punchInstructions.ElementAt(0), punchInstructions.ElementAt(1)), new Fireball());
        actionDictionary.Add(new Tuple<InputPackage[], InputPackage[]>(punchInstructions.ElementAt(2), punchInstructions.ElementAt(3)), new RedFireball());
        
        DisplayAllInstructions();
    }

    private void DisplayAllInstructions()
    {
        Debug.Log("All available punch instructions: ");
        foreach (InputPackage[] instruction in punchInstructions)
        {
            string debug = instruction[0].inputString;
            for (int i = 1; i < instruction.Length; i++)
            {
                debug += ", " + instruction[i].inputString;
            }
            Debug.Log(debug);
        }

        Tuple<InputPackage[], InputPackage[]> myKey = Tuple.Create(new InputPackage[6]{new InputPackage("6 P"), new InputPackage("6"),new InputPackage("3"), new InputPackage("2"), new InputPackage("1"), new InputPackage("4")}, new InputPackage[5]{new InputPackage("6 P"), new InputPackage("3"), new InputPackage("2"), new InputPackage("1"), new InputPackage("4")});
        BasicAction myAction = null;

        if (actionDictionary.ContainsKey(myKey))
        {
            Debug.Log("key found");
        }
        else
        {
            Debug.Log("No key found");
        }
        
        /*myAction = actionDictionary[myKey];
        if (myAction != null)
        {
            Debug.Log("Found");
        }*/
        
    }

    public BasicAction InterpretInputToAbility(InputPackage[] longestPossibleInput)
    {
        BasicAction result = null;
        
        
        
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}