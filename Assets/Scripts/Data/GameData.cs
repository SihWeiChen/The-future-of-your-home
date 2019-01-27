using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Data
{ 
    public class GameData
    {
        IO_STATE m_eIOState;
        const int m_iPlayerCount = 2;
        PlayerUIData[] m_playerUIData;

        string m_iGameEndingContent;
        string m_iGameEndingContent2;

        public IO_STATE ioState
        {
            get { return m_eIOState; }
            set { m_eIOState = value; }
        }

        public int playerCount
        {
            get { return m_iPlayerCount; }
        }

        public PlayerUIData[] playerUIDatas
        {
            get { return m_playerUIData; }
            set { m_playerUIData = value; }
        }

        public string gameEndContent
        {
            get { return m_iGameEndingContent; }
            set { m_iGameEndingContent = value; }
        }

        public string gameEndContent2
        {
            get { return m_iGameEndingContent2; }
            set { m_iGameEndingContent2 = value; }
        }

        public void Start()
        {
            m_playerUIData = new PlayerUIData[m_iPlayerCount];

            for (int i = 0; i < m_playerUIData.Length; i++)
                m_playerUIData[i] = new PlayerUIData();
        }

        public void Init()
        {
         
        }

        public void Update()
        {
             
        }
    }
}
