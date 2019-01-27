using UnityEngine;
using UnityEngine.SceneManagement;
using Data;
using Manager;

public class GameLogic : MonoBehaviour
{
    GameLogic() { }
    static GameLogic m_instance;
    public static GameLogic GetInstance { get { return m_instance; } }

    GameData m_clsGameData;
    UIManager m_clsUIManager;
    GamePlayManager m_clsGamePlayerManager;
    AudioManager m_clsAudioManager;

    float m_fStartGameCDClock;
    const float m_fStartGameCDTime = 2.0f;

    [SerializeField] MeshRenderer m_mesPicture;

    void Awake()
    {
        Debug.LogWarning("GameLogic / Awake");

        m_instance = this;

        DontDestroyOnLoad(this);

        m_clsGameData = new GameData();
        m_clsUIManager = new UIManager();
        m_clsGamePlayerManager = new GamePlayManager();
        m_clsAudioManager = new AudioManager();

        m_clsAudioManager.Awake();
    }

    void Start()
    {
        Debug.LogWarning("GameLogic / Start");

        SceneManager.LoadScene("GameMenu", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        m_clsGameData.Start();
        m_clsUIManager.Start();
        m_clsGamePlayerManager.Start();
        m_clsAudioManager.Start();
        Init();
    }

    void Init()
    {
        m_clsGameData.Init();
        m_clsUIManager.Init();
        m_clsGamePlayerManager.Init();
        m_clsAudioManager.Init();
    }

    void Update()
    {
        m_clsGameData.Update();
        m_clsUIManager.Update();
        m_clsGamePlayerManager.Update();
        m_clsAudioManager.Update();
        DetectStartGame();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "GameMenu":
                GetGameData().ioState = Common.IO_STATE.SelectCharacter;
                break;
            default:
                break;
        }
    }

    void DetectStartGame()
    {
        if (GetGameData().playerUIDatas[0].playerReady && GetGameData().playerUIDatas[1].playerReady)
        {
            m_fStartGameCDClock += Time.deltaTime;

            if (m_fStartGameCDClock <= m_fStartGameCDTime)
                return;

            GetGameData().playerUIDatas[0].playerReady = false;
            GetGameData().playerUIDatas[1].playerReady = false;
            m_fStartGameCDClock = 0.0f;

            GetUIManager().PlayLoading();
        }
    }

    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GetGameData().ioState = Common.IO_STATE.InGame;
    }

    public void PlayAudio(AudioManager.AUDIO_TYPE r_audioType)
    {
        m_clsAudioManager.Play(r_audioType);
    }

    #region Proxy & Mediator
    public GameData GetGameData()
    {
        return m_clsGameData;
    }

    public UIManager GetUIManager()
    {
        return m_clsUIManager;
    }

    public GamePlayManager GetGamePlayerManager()
    {
        return m_clsGamePlayerManager;
    }
    #endregion
}
