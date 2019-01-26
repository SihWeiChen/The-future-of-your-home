using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class PlayerUIItemController : MonoBehaviour
    {
        [SerializeField] Image[] m_imgNumBGs;
        [SerializeField] Text[] m_txtNumTexts;
        [SerializeField] Image m_imgCharacterBG;
        [SerializeField] Image m_imgCharacterIcon;

        void Start()
        {

        }

        public void Init()
        {
            for (int i = 0; i < m_imgNumBGs.Length; i++)
                HideSign(i);
        }

        void Update()
        {

        }

        public void ShowSign(int v_playerID)
        {
            m_imgNumBGs[v_playerID].enabled = true;
            m_txtNumTexts[v_playerID].enabled = true;
        }

        public void HideSign(int v_playerID)
        {
            m_imgNumBGs[v_playerID].enabled = false;
            m_txtNumTexts[v_playerID].enabled = false;
        }

        public void HideSignAll()
        {
            for (int i = 0; i < m_imgNumBGs.Length; i++)
            {
                m_imgNumBGs[i].enabled = false;
                m_txtNumTexts[i].enabled = false;
            }
        }

        public void DetermineCharacter()
        {
            GameLogic.GetInstance.PlayAudio(Manager.AudioManager.AUDIO_TYPE.Click001);

            Color colBG = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            Color colIcon = new Color(0.45f, 0.45f, 0.45f, 1.0f);
            m_imgCharacterBG.color = colBG;
            m_imgCharacterIcon.color = colIcon;
        }
    }
}
