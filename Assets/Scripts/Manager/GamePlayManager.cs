using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using Common;
using Data;

public class GamePlayManager : IPlayerEvent
{
    public enum RegistType
    {
        PlayerController,
        StateController,
        QuestionController,
    }

    public enum ChooseState
    {
        WaitOther,
        End,
    }
    ChooseState m_chooseState = ChooseState.WaitOther;


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

    bool bFirst = true;
    public void Update()
    {
        if (GameLogic.GetInstance.GetGameData().ioState == IO_STATE.InGame)
        {
            if(bFirst == true)
            {
                PlayerUIData[] data = GameLogic.GetInstance.GetGameData().playerUIDatas;
                for (int i = 0; i < data.Length; i++)
                {
                    ActorDef actor = (ActorDef)data[i].uiPos;
                    SetPlayerIcon(i, actor);
                }
                SetQuestion(GetQuestionID());
                bFirst = false;
            }

            switch(m_chooseState)
            {
                case ChooseState.WaitOther:
                    bool allSelect = true;
                    foreach(PlayerController player in playerList)
                    {
                        if (player.m_playerID >= GameLogic.GetInstance.GetGameData().playerCount)
                            continue;
                        if (player.bSelected == false)
                        {
                            allSelect = false;
                            break;
                        }
                    }
                    if (allSelect == true)
                    {
                        m_chooseState = ChooseState.End;
                    }
                    Debug.Log("ChooseState.WaitOther");
                    break;

                case ChooseState.End:

                    int answer = 1;

                    int life = TableData.Init.GetChooseTableData(answer).ChangeFeel;
                    int quality = TableData.Init.GetChooseTableData(answer).ChangeQuality;
                    int money = TableData.Init.GetChooseTableData(answer).ChangeMoney;

                    stateList.SetLife(life);
                    stateList.SetMoney(money);
                    stateList.SetQuality(quality);

                    m_questionState = (QuestionState) TableData.Init.GetChooseTableData(answer).OpenEventNID;

                    foreach(PlayerController player in playerList)
                    {
                        player.bSelected = false;
                    }

                    SetQuestion(GetQuestionID());
                    Debug.Log("ChooseState.End");
                    break;
            }
        }
    }

    public void Regist(RegistType v_type, object r_object)
    {
        switch (v_type)
        {
            case RegistType.PlayerController:
                playerList = ((List<PlayerController>)r_object);
                break;
            case RegistType.StateController:
                stateList = (StateController)r_object;

                stateList.SetLife(GameSetting.Life);
                stateList.SetMoney(GameSetting.Money);
                stateList.SetQuality(GameSetting.Quality);

                break;
            case RegistType.QuestionController:
                question = (QuestionController)r_object;
                break;
        }
    }

    public void SetStateValue(Param_STATE state, int value)
    {
        switch(state)
        {
            case Param_STATE.Life:
                break;
            case Param_STATE.Money:
                break;
            case Param_STATE.Quality:
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

    public void SetPlayerSelect(int PlayerID, int selectIndex)
    {
        playerList[PlayerID].SelectItem(selectIndex);
        playerList[PlayerID].bSelected = true;
    }

    public void PlayerIOCommand(int v_playerID, IO_Command r_ioCommand)
    {
        Debug.Log("v_playerID: " + v_playerID);
        Debug.Log("IO_Command: " + r_ioCommand.ToString());
        PlayerController player = playerList[v_playerID];
        switch (r_ioCommand)
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
                SetPlayerSelect(v_playerID, 2);
                //SetQuestion(Random.Range(0, 21));
                break;
        }
    }

    public void SetQuestion(int eventID)
    {
        Debug.Log("SetQuestion eventID: " + eventID);
        if(eventID == 0)
        {
            Debug.LogError("Error");
            eventID = 1;
        }
        GameEventTableData data = TableData.Init.GetEventTableData(eventID);
        Debug.Log("SetQuestion ChooseID1: " + data.ChooseID1);
        if (data.ChooseID1 == 0)
        {
            Debug.LogError("Error1");
            data.ChooseID1 = 1;
        }
        string choose1 = TableData.Init.GetChooseTableData(data.ChooseID1).ChooseName;
        Debug.Log("SetQuestion ChooseID2: " + data.ChooseID2);
        if (data.ChooseID2 == 0)
        {
            Debug.LogError("Error2");
            data.ChooseID2 = 1;
        }
        string choose2 = TableData.Init.GetChooseTableData(data.ChooseID2).ChooseName;
        Debug.Log("SetQuestion ChooseID3: " + data.ChooseID3);
        if (data.ChooseID3 == 0)
        {
            Debug.LogError("Error3");
            data.ChooseID3 = 1;
        }
        string choose3 = TableData.Init.GetChooseTableData(data.ChooseID3).ChooseName;
        question.SetQuestionString(data.EventName, choose1, choose2, choose3);
    }

    public enum QuestionState
    {
        Demo = 0,
        Creator = 1,
        Develop = 2,
        Fight = 3,
        All = 4,
    }
    QuestionState m_questionState = QuestionState.Demo;


    public enum QuestionEndID
    {
        Demo = 0,
        Creator = 20,
        Develop = 39,
        Fight = 60,
    }

    public enum QuestionPrioity
    {
        Dad = 0,
        Mom = 1,
        Daughter = 2,
        Son = 3,
    }

    public int GetQuestionID()
    {
        int questionID = 0;
        switch(m_questionState)
        {
            case QuestionState.Demo:
                questionID = 0;
                break;
            case QuestionState.Creator:
                questionID = Random.Range((int)QuestionEndID.Demo, (int)QuestionEndID.Creator)+1;
                break;
            case QuestionState.Develop:
                questionID = Random.Range((int)QuestionEndID.Creator, (int)QuestionEndID.Develop)+1;
                break;
            case QuestionState.Fight:
                questionID = Random.Range((int)QuestionEndID.Develop, (int)QuestionEndID.Fight)+1;
                break;
            default:
                questionID = Random.Range((int)QuestionEndID.Demo, (int)QuestionEndID.Fight)+1;
                break;
        }
        return questionID;
    }
}
