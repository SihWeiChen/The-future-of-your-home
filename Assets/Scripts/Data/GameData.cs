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
        bool m_bStartGame;
        PlayerUIData[] m_playerUIData;

        public bool startGame
        {
            get { return m_bStartGame; }
            set { m_bStartGame = value; }
        }

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
