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

        public IO_STATE ioState
        {
            get { return m_eIOState; }
            set { m_eIOState = value; }
        }

        public int playerCount
        {
            get { return m_iPlayerCount; }
        }

        public void Start()
        {
         
        }

        public void Init()
        {
         
        }

        public void Update()
        {
             
        }
    }
}
