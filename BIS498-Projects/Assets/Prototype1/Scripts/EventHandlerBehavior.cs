using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlerBehavior : MonoBehaviour
{
    public GameObject lever;
    // Start is called before the first frame update
    void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lever.GetComponent<LeverBehavior>().upwardState == true)
        {
            EventManagerBehavior.FlippingDownBehaviors();
        }
        else
        if (Input.GetMouseButtonDown(0) && lever.GetComponent<LeverBehavior>().downwardState == true)
        {
            EventManagerBehavior.FlippingUpBehaviors();
        }
    }
}
