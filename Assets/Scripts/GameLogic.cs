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

    void Awake()
    {
        Debug.LogWarning("GameLogic / Awake");

        m_instance = this;

        DontDestroyOnLoad(this);

        m_clsGameData = new GameData();
        m_clsUIManager = new UIManager();
    }

    void Start()
    {
        Debug.LogWarning("GameLogic / Start");

        SceneManager.LoadScene("GameMenu", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        m_clsGameData.Start();
        m_clsUIManager.Start();
        Init();
    }

    void Init()
    {
        m_clsGameData.Init();
        m_clsUIManager.Init();
    }

    void Update()
    {
        m_clsGameData.Update();
        m_clsUIManager.Update();
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

    #region Proxy & Mediator
    public GameData GetGameData()
    {
        return m_clsGameData;
    }

    public UIManager GetUIManager()
    {
        return m_clsUIManager;
    }
    #endregion
}
