using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlerBehavior : MonoBehaviour
{
    private GameObject lever;
    private GameObject leverHandle;
    
    void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");
        leverHandle = GameObject.FindGameObjectWithTag("LeverHandle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null && raycastHit.transform.gameObject.CompareTag("LeverHandle")
                                                 && !lever.GetComponent<LeverBehavior>().currentlyFlipping)
                {
                    if (lever.GetComponent<LeverBehavior>().upwardState)
                    {
                        EventManagerBehavior.FlipDownStartBehaviors();
                    }
                    else
                    {
                        EventManagerBehavior.FlipUpStartBehaviors();
                    }
                }
            }
        }
    }
}
