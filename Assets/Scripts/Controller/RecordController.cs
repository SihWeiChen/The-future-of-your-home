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

        bool m_bRoting;
        float m_fRotValue;
        const float m_fRotTime = 2.0f;

        void Start()
        {
            m_imgPicture.enabled = false;
            m_imgBG.enabled = false;
            m_bRoting = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowRecord();
            }

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
            m_imgPicture.enabled = true;
            m_imgBG.enabled = true;
            m_anim.Play();
            m_bRoting = true;

            m_fRotValue = 0.0f;
            m_imgPicture.color = new Color(1.0f, 1.0f, 1.0f, m_fRotValue);
        }

        void ScreenShot()
        {
            Texture2D picture = CameraHelper.CaptureScreenshot2(new Rect() { width = 2850.0f, height = 1500.0f });
            m_imgPicture.texture = picture;
        }
    }
}