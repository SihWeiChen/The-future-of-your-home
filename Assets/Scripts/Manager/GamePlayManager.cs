using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Controller;
using Common;

public class GamePlayManager
{
    public enum RegistType
    {
        PlayerController,
        StateController,
    }

    List<PlayerController> playerList = new List<PlayerController>();
    List<int> stateList = new List<int>();

    List<int> itemSelectList = new List<int>();

    public void Init()
    {

    }
    public void Start()
    {

    }
    public void Awake()
    {

    }
    public void Update()
    {

    }

    public void Regist(RegistType v_type, object r_object)
    {
        switch (v_type)
        {
            case RegistType.PlayerController:
                playerList = (List<PlayerController>)r_object;
                break;
            case RegistType.StateController:
                stateList = (List<int>)r_object;
                break;
        }
    }


    public void SetPlayerIcon(int PlayerID, Common.ActorDef actor)
    {
        playerList[PlayerID].ChangeActor(actor);
    }

    public void SetPlayerItem(int PlayerID, Common.EventItem item1, Common.EventItem item2, Common.EventItem item3)
    {
        playerList[PlayerID].ChangeItem(item1, item2, item3);
    }

    public void PlayerCommand(int v_playerID, IO_Command r_ioCommand)
    {
        PlayerController player = playerList[v_playerID];
        switch(r_ioCommand)
        {
            case IO_Command.Left:
                break;
            case IO_Command.Right:
                break;
        }
    }
}
