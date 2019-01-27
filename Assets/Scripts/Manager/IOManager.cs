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

        void Start()
        {

        }

        void Update()
        {
            #region 1P
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
            #endregion

            #region 2P
            // ========= 2P
            if (Input.GetButtonDown("P2_B"))
                P2_B();

            if (Input.GetButtonDown("P2_D"))
                P2_D();

            if (Input.GetButtonDown("P2_A"))
                P2_A();

            if (Input.GetButtonDown("P2_C"))
                P2_C();

            if (Input.GetKeyDown(KeyCode.Z))
                P2_Left();

            if (Input.GetKeyDown(KeyCode.X))
                P2_Right();
            #endregion
        }

        void P1_A()
        {
            Debug.Log(string.Format("P1_A"));
            switch (GameLogic.GetInstance.GetGameData().ioState)
            {
                case IO_STATE.None:
                    break;
                case IO_STATE.SelectCharacter:

                    if (GameLogic.GetInstance.GetGameData().playerUIDatas[0].playerReady == true)
                        break;

                    //GameLogic.GetInstance.GetGameData().playerUIDatas[0].playerReady = true;
                    GameLogic.GetInstance.GetUIManager().PlayerIOCommand(0, IO_Command.A);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(0, IO_Command.A);
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
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(0, IO_Command.B);
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
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(0, IO_Command.C);
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
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(0, IO_Command.D);
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
                    if (GameLogic.GetInstance.GetGameData().playerUIDatas[0].playerReady == true)
                        break;
                    GameLogic.GetInstance.GetUIManager().PlayerIOCommand(0, IO_Command.Right);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(0, IO_Command.Right);
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
                    if (GameLogic.GetInstance.GetGameData().playerUIDatas[0].playerReady == true)
                        break;
                    GameLogic.GetInstance.GetUIManager().PlayerIOCommand(0, IO_Command.Left);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(0, IO_Command.Left);
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

                    if (GameLogic.GetInstance.GetGameData().playerUIDatas[1].playerReady == true)
                        break;

                    //GameLogic.GetInstance.GetGameData().playerUIDatas[1].playerReady = true;
                    GameLogic.GetInstance.GetUIManager().PlayerIOCommand(1, IO_Command.A);

                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(1, IO_Command.A);
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
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(1, IO_Command.B);
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
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(1, IO_Command.C);
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
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(1, IO_Command.D);
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
                    if (GameLogic.GetInstance.GetGameData().playerUIDatas[1].playerReady == true)
                        break;
                        
                    GameLogic.GetInstance.GetUIManager().PlayerIOCommand(1, IO_Command.Right);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(1, IO_Command.Right);
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
                    if (GameLogic.GetInstance.GetGameData().playerUIDatas[1].playerReady == true)
                        break;
                    GameLogic.GetInstance.GetUIManager().PlayerIOCommand(1, IO_Command.Left);
                    break;
                case IO_STATE.InGame:
                    GameLogic.GetInstance.GetGamePlayerManager().PlayerIOCommand(1, IO_Command.Left);
                    break;
                default:
                    break;
            }
        }
    }
}
