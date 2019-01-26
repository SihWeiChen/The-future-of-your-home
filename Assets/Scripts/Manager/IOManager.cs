using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Manager
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
            if (Input.GetButtonDown("P1_B"))
                P1_B();

            if (Input.GetButtonDown("P1_D"))
                P1_D();

            if (Input.GetButtonDown("P1_A"))
                P1_A();

            if (Input.GetButtonDown("P1_C"))
                P1_C();

            float fP1_H = Input.GetAxis("P1_Horizontal");
            float fP1_V = Input.GetAxis("P1_Vertical");

            if (fP1_H >= 1.0f)
                P1_Right();
            else if (fP1_H <= -1.0f)
                P1_Left();

            // ========= 2P
            if (Input.GetButtonDown("P2_B"))
                P2_B();

            if (Input.GetButtonDown("P2_D"))
                P2_D();

            if (Input.GetButtonDown("P2_A"))
                P2_A();

            if (Input.GetButtonDown("P2_C"))
                P2_C();




            //Debug.Log(string.Format("X11: {0}", fX11));
            //Debug.Log(string.Format("Y11: {0}", fY11));
        }

        void P1_A()
        {
            Debug.Log(string.Format("P1_A"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P1_B()
        {
            Debug.Log(string.Format("P1_B"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P1_C()
        {
            Debug.Log(string.Format("P1_C"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P1_D()
        {
            Debug.Log(string.Format("P1_D"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P1_Right()
        {
            Debug.Log(string.Format("P1_Right"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P1_Left()
        {
            Debug.Log(string.Format("P1_Left"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P2_A()
        {
            Debug.Log(string.Format("P2_A"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P2_B()
        {
            Debug.Log(string.Format("P2_B"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P2_C()
        {
            Debug.Log(string.Format("P2_C"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }

        void P2_D()
        {
            Debug.Log(string.Format("P2_D"));
            switch (IO_STATE.None)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    break;
                case IO_STATE.InGame:
                    break;
                default:
                    break;
            }
        }
    }
}
