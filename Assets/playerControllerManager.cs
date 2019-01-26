using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

public class playerControllerManager : MonoBehaviour
{
    public List<PlayerController> m_playerList;
    // Start is called before the first frame update
    void Start()
    {
        GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.PlayerController, m_playerList);
    }
}
