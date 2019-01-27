using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class PlayerUIData
    {
        int m_iUIPos;
        bool m_bPlayerReady;

        public PlayerUIData()
        {
            m_iUIPos = -1;
        }

        public int uiPos
        {
            get { return m_iUIPos; }
            set 
            {
                if (m_iUIPos != -1)
                {
                    if (value == 0)
                        GameLogic.GetInstance.PlayAudio(Manager.AudioManager.AUDIO_TYPE.Father);

                    if (value == 1)
                        GameLogic.GetInstance.PlayAudio(Manager.AudioManager.AUDIO_TYPE.Mother);

                    if (value == 2)
                        GameLogic.GetInstance.PlayAudio(Manager.AudioManager.AUDIO_TYPE.Daughter);

                    if (value == 3)
                        GameLogic.GetInstance.PlayAudio(Manager.AudioManager.AUDIO_TYPE.Son);
                }

                m_iUIPos = value;

                if (m_iUIPos > 3)
                    m_iUIPos = 3;
                else if (m_iUIPos < 0)
                    m_iUIPos = 0;
            }
        }

        public bool playerReady
        {
            get { return m_bPlayerReady; }
            set { m_bPlayerReady = value; }
        }
    }
}
