using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{ 
    public class AudioManager
    {
        public enum AUDIO_TYPE
        {
            Father = 0,
        }

        Transform m_tranAudioManager;

        AudioSource m_audio_father;
        AudioSource m_audio_mother;
        AudioSource m_audio_daughter;
        AudioSource m_audio_son;

        public AudioManager()
        {}

        public void Awake()
        {
            m_tranAudioManager = GameObject.Find("AudioManager").transform;

            m_audio_father = m_tranAudioManager.transform.Find("aud_father").GetComponent<AudioSource>();
            m_audio_mother = m_tranAudioManager.transform.Find("aud_mother").GetComponent<AudioSource>();
            m_audio_daughter = m_tranAudioManager.transform.Find("aud_daughter").GetComponent<AudioSource>();
            m_audio_son = m_tranAudioManager.transform.Find("aud_son").GetComponent<AudioSource>();
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

        public void Play(AUDIO_TYPE r_audioType)
        {
            switch (r_audioType)
            {
                case AUDIO_TYPE.Father:
                    m_audio_father.Stop();
                    m_audio_father.Play();
                    break;
                default:
                    break;
            }
        }
    }
}
