using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Data;

namespace Controller
{ 
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] PlayerUIItemController[] m_playerUIItemController;


        private void Awake()
        {

        }

        public void Start()
        {
            Init();
            GameLogic.GetInstance.GetUIManager().Regist(Manager.UIManager.UI_REGIST_TYPE.PlayerUIController, this);
        }

        public void Init()
        {
            for (int i = 0; i < m_playerUIItemController.Length; i++)
                m_playerUIItemController[i].Init();

            InitSettingPlayerIDData();

        }

        public void Update()
        {

        }

        public void Command(int v_iPlayerID, IO_Command r_command)
        {
            switch (r_command)
            {
                case IO_Command.Left:
                    GameLogic.GetInstance.GetGameData().playerUIDatas[v_iPlayerID].uiPos -= 1;
                    break;
                case IO_Command.Right:
                    GameLogic.GetInstance.GetGameData().playerUIDatas[v_iPlayerID].uiPos += 1;
                    break;
                case IO_Command.A:
                    DetermineCharacter(v_iPlayerID);
                    break;
                default:
                    break;
            }
            UpdateUI();
        }

        void InitSettingPlayerIDData()
        {
            int iPlayerCount = GameLogic.GetInstance.GetGameData().playerCount;

            GameLogic.GetInstance.GetGameData().playerUIDatas[0].uiPos = 0;
            GameLogic.GetInstance.GetGameData().playerUIDatas[1].uiPos = 0;

            UpdateUI();
        }

        public void SetPlayerToPos(int v_playerID, int v_pos)
        {
            GameLogic.GetInstance.GetGameData().playerUIDatas[v_playerID].uiPos = v_pos;
            UpdateUI();
        }

        void DetermineCharacter(int v_playerID)
        {
            int iDeterminePos = GameLogic.GetInstance.GetGameData().playerUIDatas[v_playerID].uiPos;
            m_playerUIItemController[iDeterminePos].DetermineCharacter();
        }

        void UpdateUI()
        {
            for (int i = 0; i < m_playerUIItemController.Length; i++)
                m_playerUIItemController[i].HideSignAll();

            for (int i = 0; i < GameLogic.GetInstance.GetGameData().playerUIDatas.Length; i++)
            {
                int iPos = GameLogic.GetInstance.GetGameData().playerUIDatas[i].uiPos;

                if (iPos == -1)
                    return;


                m_playerUIItemController[iPos].ShowSign(i);
            }
        }
    }
}
