using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iotest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Debug.Log(string.Format("JoystickButton - A"));
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
            Debug.Log(string.Format("JoystickButton - 0"));

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
            Debug.Log(string.Format("JoystickButton - 1"));

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
            Debug.Log(string.Format("JoystickButton - 2"));

        if (Input.GetKeyDown(KeyCode.JoystickButton3))
            Debug.Log(string.Format("JoystickButton - 3"));

        if (Input.GetKeyDown(KeyCode.JoystickButton4))
            Debug.Log(string.Format("JoystickButton - 4"));
    }
}
