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
    }
}
