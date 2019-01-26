using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Controller;
using Common;
using Data;

public class GamePlayManager
{
    public enum RegistType
    {
        PlayerController,
        StateController,
        QuestionController,
    }

    List<PlayerController> playerList = new List<PlayerController>();
    List<int> stateList = new List<int>();

    List<int> itemSelectList = new List<int>();
    QuestionController question;
    public void Init()
    {

    }
    public void Start()
    {
        PlayerUIData[] data = GameLogic.GetInstance.GetGameData().playerUIDatas;
        for(int i = 0; i < data.Length; i++)
        {
            ActorDef actor = (ActorDef)data[i].uiPos;
            SetPlayerIcon(i, actor);
        }
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
            case RegistType.QuestionController:
                question = (QuestionController)r_object;
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

                //break;

            case IO_Command.Right:

                //break;

            case IO_Command.A:
            case IO_Command.B:
            case IO_Command.C:
            case IO_Command.D:
                SetQuestion(Random.Range(0, 21));
                break;
        }
    }

    public void SetQuestion(int eventID)
    {
        question.SetQuestionString(TableData.Init.GetEventTableData(eventID).EventName);
    }
}
