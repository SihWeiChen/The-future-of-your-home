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
    StateController stateList = new StateController();

    List<int> itemSelectList = new List<int>();
    QuestionController question;
    public void Init()
    {

    }
    public void Start()
    {
    }

    public void Awake()
    {

    }
    bool bFirst = false;
    public void Update()
    {
        if(bFirst == false)
        {
            try
            {
                PlayerUIData[] data = GameLogic.GetInstance.GetGameData().playerUIDatas;
                for (int i = 0; i < data.Length; i++)
                {
                    ActorDef actor = (ActorDef)data[i].uiPos;
                    SetPlayerIcon(i, actor);
                }
                bFirst = true;
            }
            catch
            {

            }
        }
    }

    public void Regist(RegistType v_type, object r_object)
    {
        switch (v_type)
        {
            case RegistType.PlayerController:
                playerList.Add((PlayerController)r_object);
                break;
            case RegistType.StateController:
                stateList = (StateController)r_object;
                break;
            case RegistType.QuestionController:
                question = (QuestionController)r_object;
                break;
        }
    }


    public void SetPlayerIcon(int PlayerID, Common.ActorDef actor)
    {
        Debug.Log("playerList" + playerList.Count);
        Debug.Log("PlayerID" + PlayerID);
        Debug.Log("actor" + actor.ToString());
        playerList[PlayerID].ChangeActor(actor);
    }

    public void SetPlayerItem(int PlayerID, Common.EventItem item1, Common.EventItem item2, Common.EventItem item3)
    {
        playerList[PlayerID].ChangeItem(item1, item2, item3);
    }

    public void SetPlayerSelect(int PlayerID, int selectIndex)
    {
        playerList[PlayerID].SelectItem(selectIndex);
    }

    public void PlayerCommand(int v_playerID, IO_Command r_ioCommand)
    {
        PlayerController player = playerList[v_playerID];
        switch(r_ioCommand)
        {
            case IO_Command.Left:
                SetPlayerSelect(v_playerID, 0);
                break;

            case IO_Command.Right:
                SetPlayerSelect(v_playerID, 1);
                break;

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
