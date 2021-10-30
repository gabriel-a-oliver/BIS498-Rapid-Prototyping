using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLibrary : MonoBehaviour
{
    private Dictionary<ManyKeys<InputPackage[], InputPackage[], InputPackage[]>, BasicAction> actionDictionary;

    public struct ManyKeys<T1, T2, T3> {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public ManyKeys(T1 item1, T2 item2, T3 item3) { Item1 = item1; Item2 = item2;
            Item3 = item3;
        }
    }

    public static class ManyKeys { // for type-inference goodness.
        public static ManyKeys<T1,T2, T3> Create<T1,T2, T3>(T1 item1, T2 item2, T3 item3) { 
            return new ManyKeys<T1,T2, T3>(item1, item2, item3); 
        }
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
