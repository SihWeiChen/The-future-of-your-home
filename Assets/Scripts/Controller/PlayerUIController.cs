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
        PlayerUIData[] m_playerUIData;

        private void Awake()
        {
            m_playerUIData = new PlayerUIData[GameLogic.GetInstance.GetGameData().playerCount];

            for (int i = 0; i < m_playerUIData.Length; i++)
                m_playerUIData[i] = new PlayerUIData();
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
                    m_playerUIData[v_iPlayerID].uiPos -= 1;
                    break;
                case IO_Command.Right:
                    m_playerUIData[v_iPlayerID].uiPos += 1;
                    break;
                default:
                    break;
            }
            UpdateUI();
        }

        void InitSettingPlayerIDData()
        {
            int iPlayerCount = GameLogic.GetInstance.GetGameData().playerCount;

            m_playerUIData[0].uiPos = 0;
            m_playerUIData[1].uiPos = 0;

            UpdateUI();
        }

        public void SetPlayerToPos(int v_playerID, int v_pos)
        {
            m_playerUIData[v_playerID].uiPos = v_pos;

            UpdateUI();
        }

        void UpdateUI()
        {
            for (int i = 0; i < m_playerUIItemController.Length; i++)
                m_playerUIItemController[i].HideSignAll();

            for (int i = 0; i < m_playerUIData.Length; i++)
            {
                int iPos = m_playerUIData[i].uiPos;

                if (iPos == -1)
                    return;


                m_playerUIItemController[iPos].ShowSign(i);
            }
        }
    }
}
