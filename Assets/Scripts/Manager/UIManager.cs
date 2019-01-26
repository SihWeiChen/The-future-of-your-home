using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using Common;

namespace Manager
{
    public class UIManager
    {
        public enum UI_REGIST_TYPE
        {
            PlayerUIController = 0,
        }

        PlayerUIController m_lisPlayerUIController;

        public UIManager()
        {

        }

        public void Start()
        {
            
        }

        public void Regist(UI_REGIST_TYPE r_type, object r_obj)
        {
            switch (r_type)
            {
                case UI_REGIST_TYPE.PlayerUIController:
                    m_lisPlayerUIController = r_obj as PlayerUIController;
                    break;
                default:
                    break;
            }
        }

        public void Init()
        {
             
        }

        public void Update()
        {

        }

        public void PlayerCommand(int v_playerID, IO_Command r_ioCommand)
        {
            m_lisPlayerUIController.Command(v_playerID, r_ioCommand);
        }
    }
}
