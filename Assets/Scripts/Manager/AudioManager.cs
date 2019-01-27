using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Manager
{ 
    public class AudioManager
    {
        public enum BGM_LEVEL
        {
            None = 0,
            Level01,
            Level02,
            Level03, 
        }

        public enum AUDIO_TYPE
        {
            Father = 0,
            Mother,
            Daughter,
            Son,
            MenuBGM,
            Click001,
            Confirm,
            FailGame,
            GetMoney,
        }

        Transform m_tranAudioManager;

        AudioSource m_audio_father;
        AudioSource m_audio_mother;
        AudioSource m_audio_daughter;
        AudioSource m_audio_son;
        AudioSource m_audio_menu_bgm;
        AudioSource m_audio_click001;
        AudioSource m_audio_confirm;
        AudioSource m_audio_failGame;
        AudioSource m_audio_getMoney;
        AudioSource m_audio_game_bgm;
        AudioSource[] m_audioGroup_BGM_Level01;
        AudioSource[] m_audioGroup_BGM_Level02;
        AudioSource[] m_audioGroup_BGM_Level03;

        BGM_LEVEL m_eCurBGM_LEVEL;

        public AudioManager()
        {}

        public void Awake()
        {
            m_tranAudioManager = GameObject.Find("AudioManager").transform;

            m_audio_father = m_tranAudioManager.transform.Find("aud_father").GetComponent<AudioSource>();
            m_audio_mother = m_tranAudioManager.transform.Find("aud_mother").GetComponent<AudioSource>();
            m_audio_daughter = m_tranAudioManager.transform.Find("aud_daughter").GetComponent<AudioSource>();
            m_audio_son = m_tranAudioManager.transform.Find("aud_son").GetComponent<AudioSource>();
            m_audio_menu_bgm = m_tranAudioManager.transform.Find("aud_menu_bgm").GetComponent<AudioSource>();
            m_audio_click001 = m_tranAudioManager.transform.Find("aud_click001").GetComponent<AudioSource>();
            m_audio_confirm = m_tranAudioManager.transform.Find("aud_confirm").GetComponent<AudioSource>();
            m_audio_failGame = m_tranAudioManager.transform.Find("aud_failGame").GetComponent<AudioSource>();
            m_audio_getMoney = m_tranAudioManager.transform.Find("aud_getMoney").GetComponent<AudioSource>();
            m_audio_game_bgm = m_tranAudioManager.transform.Find("aud_game_bgm").GetComponent<AudioSource>();

            m_audioGroup_BGM_Level01 = m_tranAudioManager.transform.Find("BGM_level01").GetComponentsInChildren<AudioSource>();
            m_audioGroup_BGM_Level02 = m_tranAudioManager.transform.Find("BGM_level02").GetComponentsInChildren<AudioSource>();
            m_audioGroup_BGM_Level03 = m_tranAudioManager.transform.Find("BGM_level03").GetComponentsInChildren<AudioSource>();

            Play(AUDIO_TYPE.MenuBGM);

            m_eCurBGM_LEVEL = BGM_LEVEL.None;
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
                case AUDIO_TYPE.Mother:
                    m_audio_mother.Stop();
                    m_audio_mother.Play();
                    break;
                case AUDIO_TYPE.Daughter:
                    m_audio_daughter.Stop();
                    m_audio_daughter.Play();
                    break;
                case AUDIO_TYPE.Son:
                    m_audio_son.Stop();
                    m_audio_son.Play();
                    break;
                case AUDIO_TYPE.MenuBGM:
                    m_audio_menu_bgm.Stop();
                    m_audio_menu_bgm.Play();
                    break;
                case AUDIO_TYPE.Click001:
                    m_audio_click001.Stop();
                    m_audio_click001.Play();
                    break;
                case AUDIO_TYPE.Confirm:
                    m_audio_confirm.Stop();
                    m_audio_confirm.Play();
                    break;
                case AUDIO_TYPE.FailGame:
                    m_audio_failGame.Stop();
                    m_audio_failGame.Play();
                    break;
                case AUDIO_TYPE.GetMoney:
                    m_audio_getMoney.Stop();
                    m_audio_getMoney.Play();
                    break;
                default:
                    break;
            }
        }

        public void Stop(AUDIO_TYPE r_audioType)
        {
            switch (r_audioType)
            {
                case AUDIO_TYPE.Father:
                    m_audio_father.Stop();
                    break;
                case AUDIO_TYPE.Mother:
                    m_audio_mother.Stop();
                    break;
                case AUDIO_TYPE.Daughter:
                    m_audio_daughter.Stop();
                    break;
                case AUDIO_TYPE.Son:
                    m_audio_son.Stop();
                    break;
                case AUDIO_TYPE.MenuBGM:
                    m_audio_menu_bgm.Stop();
                    break;
                case AUDIO_TYPE.Click001:
                    m_audio_click001.Stop();
                    break;
                case AUDIO_TYPE.Confirm:
                    m_audio_confirm.Stop();
                    break;
                case AUDIO_TYPE.FailGame:
                    m_audio_failGame.Stop();
                    break;
                case AUDIO_TYPE.GetMoney:
                    m_audio_getMoney.Stop();
                    break;
                default:
                    break;
            }
        }

        public void PlayBGM()
        {
            Debug.Log("Life: " + GameSetting.Life);

            if (GameSetting.Life > 13)
            {
                if (m_eCurBGM_LEVEL != BGM_LEVEL.Level01)
                {
                    int iRandomIndex = Random.Range(0, m_audioGroup_BGM_Level01.Length);
                    Debug.Log("iRandomIndex-1: " + iRandomIndex);
                    m_eCurBGM_LEVEL = BGM_LEVEL.Level01;
                    m_audio_game_bgm.clip = m_audioGroup_BGM_Level01[iRandomIndex].clip;
                    m_audio_game_bgm.Play();
                }
            }
            else if (GameSetting.Life >= 7 && GameSetting.Life <= 13)
            {
                if (m_eCurBGM_LEVEL != BGM_LEVEL.Level02)
                {
                    int iRandomIndex = Random.Range(0, m_audioGroup_BGM_Level02.Length);
                    Debug.Log("iRandomIndex-2: " + iRandomIndex);
                    m_eCurBGM_LEVEL = BGM_LEVEL.Level02;
                    m_audio_game_bgm.clip = m_audioGroup_BGM_Level02[iRandomIndex].clip;
                    m_audio_game_bgm.Play();
                }
            }
            else if (GameSetting.Life < 7)
            {
                if (m_eCurBGM_LEVEL != BGM_LEVEL.Level03)
                {
                    int iRandomIndex = Random.Range(0, m_audioGroup_BGM_Level03.Length);
                    Debug.Log("iRandomIndex-3: " + iRandomIndex);
                    m_eCurBGM_LEVEL = BGM_LEVEL.Level03;
                    m_audio_game_bgm.clip = m_audioGroup_BGM_Level03[iRandomIndex].clip;
                    m_audio_game_bgm.Play();
                }
            }
        }
    }
}
