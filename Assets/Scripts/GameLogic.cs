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
