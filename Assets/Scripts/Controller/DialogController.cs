﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{ 
    public class DialogController : MonoBehaviour
    {
        [SerializeField] Animation m_animFrame;

        public void Play_Show()
        {
            m_animFrame.Play("ShowFrame");
        }

        public void Play_Close()
        {
            m_animFrame.Play("CloseFrame");
        }
    }
}
