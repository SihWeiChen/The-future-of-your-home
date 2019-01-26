using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Manager
{
    public class IOManager : MonoBehaviour
    {
        bool m_bPressRight_P1;
        bool m_bPressLeft_P1;

        bool m_bPressRight_P2;
        bool m_bPressLeft_P2;

        bool m_bReady_P1;
        bool m_bReady_P2;

        void Start()
        {

        }

        void Update()
        {

            //if (Input.GetKeyDown(KeyCode.JoystickButton0))
            //    Debug.Log(string.Format("JoystickButton - 0"));

            //if (Input.GetKeyDown(KeyCode.JoystickButton1))
            //    Debug.Log(string.Format("JoystickButton - 1"));

            //if (Input.GetKeyDown(KeyCode.JoystickButton2))
            //    Debug.Log(string.Format("JoystickButton - 2"));

            //if (Input.GetKeyDown(KeyCode.JoystickButton3))
            //    Debug.Log(string.Format("JoystickButton - 3"));

            //if (Input.GetKeyDown(KeyCode.JoystickButton4))
                //Debug.Log(string.Format("JoystickButton - 4"));


            // ========= 1P
            if (Input.GetButtonDown("P1_B"))
                P1_B();

            if (Input.GetButtonDown("P1_D"))
                P1_D();

            if (Input.GetButtonDown("P1_A") || Input.GetKeyDown(KeyCode.P))
                P1_A();

            if (Input.GetButtonDown("P1_C"))
                P1_C();
                

            float fP1_H = Input.GetAxis("P1_Horizontal");
            float fP1_V = Input.GetAxis("P1_Vertical");

            if (fP1_H == 0)
            { 
                m_bPressRight_P1 = false;
                m_bPressLeft_P1 = false;
            }

            if (fP1_H >= 1.0f)
            {
                if (m_bPressRight_P1 == false)
                {
                    m_bPressRight_P1 = true;
                    P1_Right();
                }

            }
            else if (fP1_H <= -1.0f)
            {
                if (m_bPressLeft_P1 == false)
                {
                    m_bPressLeft_P1 = true;
                    P1_Left();
                }
            }    

            // ========= 2P


            if (Input.GetButtonDown("P2_B"))
                P2_B();

            if (Input.GetButtonDown("P2_D"))
                P2_D();

            if (Input.GetButtonDown("P2_A"))
                P2_A();

            if (Input.GetButtonDown("P2_C"))
                P2_C();

            float fP2_H = Input.GetAxis("P2_Horizontal") * Time.deltaTime * 10.0f;
            float fP2_V = Input.GetAxis("P2_Vertical") * Time.deltaTime * 10.0f;

            if (fP2_H == 0)
            {
                m_bPressRight_P2 = false;
                m_bPressLeft_P2 = false;
            }

            if (fP2_H >= 0.1f)
            {
                if (m_bPressRight_P2 == false)
                {
                    m_bPressRight_P2 = true;
                    P2_Right();
                }

            }
            else if (fP2_H <= -0.1f)
            {
                if (m_bPressLeft_P2 == false)
                {
                    m_bPressLeft_P2 = true;
                    P2_Left();
                }
            }

            DetectStartGame();
        }

        void DetectStartGame()
        {
            if (m_bReady_P1 && m_bReady_P2)
            { 
                GameLogic.GetInstance.GetGameData().startGame = true;
                m_bReady_P1 = false;
                m_bReady_P2 = false;
            }
        }

        void P1_A()
        {
            Debug.Log(string.Format("P1_A"));
            switch (GameLogic.GetInstance.GetGameData().ioState)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:

                    if (m_bReady_P1 == true)
                        break;

                    m_bReady_P1 = true;
                    GameLogic.GetInstance.GetUIManager().PlayerCommand(0, IO_Command.A);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetUIManager().PlayerCommand(0, IO_Command.A);
                    break;
                default:
                    break;
            }
        }

        void P1_B()
        {
            Debug.Log(string.Format("P1_B"));
            switch (GameLogic.GetInstance.GetGameData().ioState)
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
            switch (GameLogic.GetInstance.GetGameData().ioState)
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
            switch (GameLogic.GetInstance.GetGameData().ioState)
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
            switch (GameLogic.GetInstance.GetGameData().ioState)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    if (m_bReady_P1 == true)
                        break;
                    GameLogic.GetInstance.GetUIManager().PlayerCommand(0, IO_Command.Right);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerCommand(0, IO_Command.Right);
                    break;
                default:
                    break;
            }
        }

        void P1_Left()
        {
            Debug.Log(string.Format("P1_Left"));
            switch (GameLogic.GetInstance.GetGameData().ioState)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    if (m_bReady_P1 == true)
                        break;
                    GameLogic.GetInstance.GetUIManager().PlayerCommand(0, IO_Command.Left);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerCommand(0, IO_Command.Right);
                    break;
                default:
                    break;
            }
        }

        void P2_A()
        {
            Debug.Log(string.Format("P2_A"));
            switch (GameLogic.GetInstance.GetGameData().ioState)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:

                    if (m_bReady_P2 == true)
                        break;

                    m_bReady_P2 = true;
                    GameLogic.GetInstance.GetUIManager().PlayerCommand(1, IO_Command.A);

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
            switch (GameLogic.GetInstance.GetGameData().ioState)
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
            switch (GameLogic.GetInstance.GetGameData().ioState)
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
            switch (GameLogic.GetInstance.GetGameData().ioState)
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

        void P2_Right()
        {
            Debug.Log(string.Format("P2_Right"));
            switch (GameLogic.GetInstance.GetGameData().ioState)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    if (m_bReady_P2 == true)
                        break;

                   

                    GameLogic.GetInstance.GetUIManager().PlayerCommand(1, IO_Command.Right);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerCommand(1, IO_Command.Right);
                    break;
                default:
                    break;
            }
        }

        void P2_Left()
        {
            Debug.Log(string.Format("P2_Left"));
            switch (GameLogic.GetInstance.GetGameData().ioState)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:
                    if (m_bReady_P2 == true)
                        break;
                    GameLogic.GetInstance.GetUIManager().PlayerCommand(1, IO_Command.Left);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerCommand(1, IO_Command.Left);
                    break;
                default:
                    break;
            }
        }
    }
}
