using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Data;
using TMPro;
using UnityEngine.UI;

namespace Controller
{ 
    public class PlayerUIController : MonoBehaviour
    {
        enum LOADING_STATE
        {
            None = 0,
            Loading01,
            Loading02,
            Loading03,
            Loading04,
            Loading05,
        }

        [SerializeField] PlayerUIItemController[] m_playerUIItemController;
        [SerializeField] TextMeshProUGUI m_tmpCDTimer;
        [SerializeField] Animation m_animCDTimer;
        [SerializeField] Image m_imgLoadingBG;
        [SerializeField] TextMeshProUGUI m_tmpLoading;

        [SerializeField] Animation[] m_animCharacterScale;
        [SerializeField] TextMeshProUGUI m_tmpLogo;

        const int m_iTimes = 5;
        int m_iCurTimes;

        bool m_bStartCountDown;
        float m_fCountDownClock;
        float m_fCountDownTime = 1.0f;

        LOADING_STATE m_eCurLoadingState;
        LOADING_STATE m_eNextLoadingState;

        bool m_bStartLoading;
        float m_fStartLoadingClock;
        const float m_fStartLoadingTime = 0.15f;

        bool m_bChangeScene;
        float m_fChangeSceneClock;
        const float m_fChangeSceneTime = 3.0f;

        private void Awake()
        {

        }

        public void Start()
        {
            Init();
            GameLogic.GetInstance.GetUIManager().Regist(Manager.UIManager.UI_REGIST_TYPE.PlayerUIController, this);
            PlayAnimCharacterSacle();
        }

        public void Init()
        {
            for (int i = 0; i < m_playerUIItemController.Length; i++)
                m_playerUIItemController[i].Init();

            m_eCurLoadingState = LOADING_STATE.None;
            m_eNextLoadingState = m_eCurLoadingState;
            m_imgLoadingBG.enabled = false;
            m_tmpLoading.enabled = false;

            m_bStartLoading = false;
            m_fStartLoadingClock = 0.0f;

            m_bChangeScene = false;
            m_fChangeSceneClock = 0.0f;
            m_tmpLogo.enabled = true;
            m_tmpCDTimer.enabled = false;
            m_bStartCountDown = false;
            m_fCountDownClock = 0.0f;
            m_iCurTimes = m_iTimes;
            InitSettingPlayerIDData();
        }

        public void Update()
        {
            if (m_bStartCountDown)
            {
                m_fCountDownClock += Time.deltaTime;
                if (m_fCountDownClock >= m_fCountDownTime)
                    StartCDTimer();
            }

            DetectLoadingText();

            if (m_bStartLoading)
            {
                m_fStartLoadingClock += Time.deltaTime;
                if (m_fStartLoadingClock >= m_fStartLoadingTime)
                {
                    switch (m_eCurLoadingState)
                    {
                        case LOADING_STATE.Loading01:
                            m_eNextLoadingState = LOADING_STATE.Loading02;
                            break;
                        case LOADING_STATE.Loading02:
                            m_eNextLoadingState = LOADING_STATE.Loading03;
                            break;
                        case LOADING_STATE.Loading03:
                            m_eNextLoadingState = LOADING_STATE.Loading04;
                            break;
                        case LOADING_STATE.Loading04:
                            m_eNextLoadingState = LOADING_STATE.Loading05;
                            break;
                        case LOADING_STATE.Loading05:
                            m_eNextLoadingState = LOADING_STATE.Loading01;
                            break;
                        default:
                            break;
                    }

                    m_fStartLoadingClock = 0.0f;
                }
            }

            if (m_bChangeScene)
            {
                m_fChangeSceneClock += Time.deltaTime;
                if (m_fChangeSceneClock >= m_fChangeSceneTime)
                {
                    m_bChangeScene = false;
                    m_fChangeSceneClock = 0.0f;

                    m_bStartLoading = false;

                    GameLogic.GetInstance.ChangeSceneToGame();
                }
            }
        }

        void DetectLoadingText()
        {
            if (m_eNextLoadingState != m_eCurLoadingState)
            {
                switch (m_eNextLoadingState)
                {
                    case LOADING_STATE.Loading01:
                        m_tmpLoading.text = "LOADING.";
                        break;
                    case LOADING_STATE.Loading02:
                        m_tmpLoading.text = "LOADING..";
                        break;
                    case LOADING_STATE.Loading03:
                        m_tmpLoading.text = "LOADING...";
                        break;
                    case LOADING_STATE.Loading04:
                        m_tmpLoading.text = "LOADING....";
                        break;
                    case LOADING_STATE.Loading05:
                        m_tmpLoading.text = "LOADING.....";
                        break;
                    default:
                        break;
                }

                m_eCurLoadingState = m_eNextLoadingState;
            }
        }

        public void Command(int v_iPlayerID, IO_Command r_command)
        {
            switch (r_command)
            {
                case IO_Command.Left:
                    GameLogic.GetInstance.GetGameData().playerUIDatas[v_iPlayerID].uiPos -= 1;
                    break;
                case IO_Command.Right:
                    GameLogic.GetInstance.GetGameData().playerUIDatas[v_iPlayerID].uiPos += 1;
                    break;
                case IO_Command.A:
                    DetermineCharacter(v_iPlayerID);
                    break;
                default:
                    break;
            }
            UpdateUI();
        }

        void InitSettingPlayerIDData()
        {
            int iPlayerCount = GameLogic.GetInstance.GetGameData().playerCount;

            GameLogic.GetInstance.GetGameData().playerUIDatas[0].uiPos = 0;
            GameLogic.GetInstance.GetGameData().playerUIDatas[1].uiPos = 0;

            UpdateUI();
        }

        public void SetPlayerToPos(int v_playerID, int v_pos)
        {
            GameLogic.GetInstance.GetGameData().playerUIDatas[v_playerID].uiPos = v_pos;
            UpdateUI();
        }

        void DetermineCharacter(int v_playerID)
        {
            int iDeterminePos = GameLogic.GetInstance.GetGameData().playerUIDatas[v_playerID].uiPos;
            m_playerUIItemController[iDeterminePos].DetermineCharacter();
        }

        void UpdateUI()
        {
            for (int i = 0; i < m_playerUIItemController.Length; i++)
                m_playerUIItemController[i].HideSignAll();

            for (int i = 0; i < GameLogic.GetInstance.GetGameData().playerUIDatas.Length; i++)
            {
                int iPos = GameLogic.GetInstance.GetGameData().playerUIDatas[i].uiPos;

                if (iPos == -1)
                    return;

                m_playerUIItemController[iPos].ShowSign(i);
            }
        }

        public void PlayLoading()
        {
            m_tmpLogo.enabled = false;
            m_imgLoadingBG.enabled = true;
            m_tmpLoading.enabled = true;

            m_bStartLoading = true;
            m_tmpLoading.text = "LOADING";

            m_eNextLoadingState = LOADING_STATE.Loading01;

            m_bChangeScene = true;
        }

        public void StartCDTimer()
        {
            PlayLoading();
        }

        void PlayAnimCharacterSacle()
        {
            for (int i = 0; i < m_animCharacterScale.Length; i++)
            {
                if (m_animCharacterScale[i].isPlaying == false)
                {
                    m_animCharacterScale[i].Play();
                    Invoke("PlayAnimCharacterSacle", 0.5f);
                    return;
                }
            }
        }
    }
}
