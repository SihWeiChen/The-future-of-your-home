using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{ 
    public class RecordController : MonoBehaviour
    {
        [SerializeField] RawImage m_imgPicture;
        [SerializeField] Image m_imgBG;
        [SerializeField] Animation m_anim;
        [SerializeField] Image m_frame;
        [SerializeField] RectTransform m_tranButtons;
        [SerializeField] Text m_txtEndingContent;
        [SerializeField] Text m_txtEndingContent2;
        bool m_bRoting;
        float m_fRotValue;
        const float m_fRotTime = 2.01f;

        void Start()
        {
            GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.RecordController, this);

            m_imgPicture.enabled = false;
            m_imgBG.enabled = false;
            m_frame.enabled = false;
            m_tranButtons.gameObject.SetActive(false);
            m_txtEndingContent.text = "";
            m_txtEndingContent.enabled = false;
            m_txtEndingContent2.text = "";
            m_txtEndingContent2.enabled = false;
            m_bRoting = false;
        }

        void Update()
        {
            if (m_bRoting)
            {
                m_fRotValue += Time.deltaTime / m_fRotTime;
                m_imgPicture.color = new Color(1.0f, 1.0f, 1.0f, m_fRotValue);

                if (m_fRotValue >= 1.0f)
                {
                    m_bRoting = false;
                    m_fRotValue = 1.0f;
                    m_anim.Stop();
                    m_imgPicture.color = new Color(1.0f, 1.0f, 1.0f, m_fRotValue);
                }
            }
        }

        public void ShowRecord()
        {
            ScreenShot();
            m_txtEndingContent.text = GameLogic.GetInstance.GetGameData().gameEndContent;
            m_txtEndingContent.enabled = true;

            m_txtEndingContent2.text = GameLogic.GetInstance.GetGameData().gameEndContent2;
            m_txtEndingContent2.enabled = true;

            m_imgPicture.enabled = true;
            m_imgBG.enabled = true;
            m_frame.enabled = true;
            m_tranButtons.gameObject.SetActive(true);
            m_anim.Play();
            m_bRoting = true;

            m_fRotValue = 0.0f;
            m_imgPicture.color = new Color(1.0f, 1.0f, 1.0f, m_fRotValue);
        }

        void ScreenShot()
        {
            Texture2D picture = CameraHelper.CaptureScreenshot2(new Rect() { width = Screen.width, height = Screen.height });
            m_imgPicture.texture = picture;
        }
    }
}