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
        [SerializeField] Text m_txtFinalPlayerNum;
        [SerializeField] Animation m_animFinalPlayerNum;
        [SerializeField] ShakeController m_clsShakeController;

        bool m_bDetectFinalPlayerNumAnim;

        int m_iNowPlayerID;

        void Start()
        {

        }

        public void Init()
        {
            for (int i = 0; i < m_imgNumBGs.Length; i++)
                HideSign(i);

            m_txtFinalPlayerNum.enabled = false;
            m_bDetectFinalPlayerNumAnim = false;
        }

        void Update()
        {
            if (m_bDetectFinalPlayerNumAnim)
            {
                if (m_animFinalPlayerNum.isPlaying == false)
                {
                    m_bDetectFinalPlayerNumAnim = false;
                    m_clsShakeController.ShakeCamera(50.0f, 0.5f);
                    GameLogic.GetInstance.GetGameData().playerUIDatas[m_iNowPlayerID].playerReady = true;
                }
            }
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

        public void DetermineCharacter(int v_playerID)
        {
            GameLogic.GetInstance.PlayAudio(Manager.AudioManager.AUDIO_TYPE.Click001);

            Color colBG = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            Color colIcon = new Color(0.45f, 0.45f, 0.45f, 1.0f);
            m_imgCharacterBG.color = colBG;
            m_imgCharacterIcon.color = colIcon;

            m_iNowPlayerID = v_playerID;
            ShowFinalPlayerNum(m_iNowPlayerID);
        }

        public void ShowFinalPlayerNum(int v_playerID)
        {
            string iName = (v_playerID+1) + "P";
            m_txtFinalPlayerNum.text = iName;
            m_txtFinalPlayerNum.enabled = true;

            m_animFinalPlayerNum.Play("ShowFinalPlayerNum");
            m_bDetectFinalPlayerNumAnim = true;
        }
    }
}
