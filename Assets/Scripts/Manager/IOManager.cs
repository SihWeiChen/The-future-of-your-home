using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mamager
{
    public class IOManager : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

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


            // ========= 1P
            //if (Input.GetButtonDown("P1_Up"))
            //    Debug.Log(string.Format("P1_Up"));

            //if (Input.GetButtonDown("P1_Down"))
            //    Debug.Log(string.Format("P1_Down"));

            //if (Input.GetButtonDown("P1_Left"))
            //    Debug.Log(string.Format("P1_Left"));

            //if (Input.GetButtonDown("P1_Right"))
            //    Debug.Log(string.Format("P1_Right"));



            // ========= 2P
            //if (Input.GetButtonDown("P2_Up"))
            //    Debug.Log(string.Format("P2_Up"));

            //if (Input.GetButtonDown("P2_Down"))
            //    Debug.Log(string.Format("P2_Down"));

            //if (Input.GetButtonDown("P2_Left"))
            //    Debug.Log(string.Format("P2_Left"));

            //if (Input.GetButtonDown("P2_Right"))
            //Debug.Log(string.Format("P2_Right"));


            //float fX11 = Input.GetAxis("Horizontal");
            //float fY11 = Input.GetAxis("Vertical");

            //Debug.Log(string.Format("X11: {0}", fX11));
            //Debug.Log(string.Format("Y11: {0}", fY11));
        }

        void Up_P1()
        {
            Debug.Log(string.Format("P1_Up"));
        }

        void Up_P2()
        {
            Debug.Log(string.Format("P2_Up"));
        }
    }
}
