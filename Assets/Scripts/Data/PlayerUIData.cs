using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class PlayerUIData
    {
        int m_iUIPos;

        public PlayerUIData()
        {
            m_iUIPos = -1;
        }

        public int uiPos
        {
            get { return m_iUIPos; }
            set 
            { 
                m_iUIPos = value;

                if (m_iUIPos > 3)
                    m_iUIPos = 3;
                else if (m_iUIPos < 0)
                    m_iUIPos = 0;
            }
        }
    }
}
