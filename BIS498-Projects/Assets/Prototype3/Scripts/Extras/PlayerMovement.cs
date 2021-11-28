using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float movementConstant = 0.3f;

    public GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myPosition = me.transform.position;
        if (Keyboard.current.aKey.isPressed) {
            Debug.Log("moving left");
            //myPosition = new Vector3(myPosition.x - movementConstant, myPosition.y, myPosition.z);
            transform.Translate(-movementConstant, 0, 0);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            Debug.Log("moving right");
            //myPosition = new Vector3(myPosition.x + movementConstant, myPosition.y, myPosition.z);
            transform.Translate(movementConstant, 0, 0);

        }
    }
}
