using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLibrary : MonoBehaviour
{
    public List<InputPackage[]> punchInstructions;
    public Dictionary<ManyKeys<InputPackage[], InputPackage[]>, BasicAction> actionDictionary;

    public struct ManyKeys<T1, T2> {
        public T1 Item1;
        public T2 Item2;
        public ManyKeys(T1 item1, T2 item2) { Item1 = item1; Item2 = item2; }
    }

    public static class ManyKeys { // for type-inference goodness.
        public static ManyKeys<T1,T2> Create<T1,T2>(T1 item1, T2 item2) { 
            return new ManyKeys<T1,T2>(item1, item2); 
        }
    }

    private void Awake()
    {
        actionDictionary = new Dictionary<ManyKeys<InputPackage[], InputPackage[]>, BasicAction>();
        
        // All abilities that use the punch button
        punchInstructions = new List<InputPackage[]>();
        //punchInstructions.Add(new InputPackage[6]{new InputPackage("4"), new InputPackage("1"),new InputPackage("2"), new InputPackage("3"), new InputPackage("6"), new InputPackage("6 P")});
        punchInstructions.Add(new InputPackage[6]{new InputPackage("6 P"), new InputPackage("6"),new InputPackage("3"), new InputPackage("2"), new InputPackage("1"), new InputPackage("4")});
        punchInstructions.Add(new InputPackage[5]{new InputPackage("6 P"), new InputPackage("3"),new InputPackage("2"), new InputPackage("1"), new InputPackage("4")});
        punchInstructions.Add(new InputPackage[4]{new InputPackage("6 P"), new InputPackage("6"), new InputPackage("3"), new InputPackage("2")});
        punchInstructions.Add(new InputPackage[3]{new InputPackage("6 P"), new InputPackage("3"), new InputPackage("2")});
        
        // Fireball dictionary element
        actionDictionary.Add(new ManyKeys<InputPackage[], InputPackage[]>(punchInstructions.ElementAt(1), punchInstructions.ElementAt(1)), new Fireball());
        actionDictionary.Add(new ManyKeys<InputPackage[], InputPackage[]>(punchInstructions.ElementAt(2), punchInstructions.ElementAt(3)), new RedFireball());
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