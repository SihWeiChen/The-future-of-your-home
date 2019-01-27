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

        void Start()
        {
            
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Texture2D picture = CameraHelper.CaptureScreenshot2(new Rect() { width = 2850.0f, height = 1500.0f });
                m_imgPicture.texture = picture;
            }
        }
    }
}