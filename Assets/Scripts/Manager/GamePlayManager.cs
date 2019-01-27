using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using Common;
using Data;
using System;

public class GamePlayManager : IPlayerEvent
{
    public enum RegistType
    {
        PlayerController,
        StateController,
        QuestionController,
        DialogController,
        BGLevelUpController,
        RecordController,
    }

    public enum ChooseState
    {
        WaitOther,
        End,
        ShowAnswer,
        ShowItem,
        GameOver,
    }
    ChooseState m_chooseState = ChooseState.WaitOther;

    public enum BG_LevelUp_Item
    {
        Photo,
        Bookcase,
        Light,
        Table,
        Sofa,
        Lamp,
    }


    List<PlayerController> playerList = new List<PlayerController>();
    StateController stateList = new StateController();

    List<int> itemSelectList = new List<int>();
    QuestionController question;
    DialogController dialog;
    RecordController m_clsRecordController;

    Dictionary<BG_LevelUp_Item, BGLevelUp> dicBGLevelUp = new Dictionary<BG_LevelUp_Item, BGLevelUp>();
    Dictionary<BG_LevelUp_Item, int> dicBGLevelValue = new Dictionary<BG_LevelUp_Item, int>();

    float ShowItemTimer = 3.0f;
    float curShowItemTime = 0.0f;

    float ShowAnswerTimer = 1.0f;
    float curShowAnswerTime = 0.0f;

    int thisAnswer = 0;

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

    List<ActorDef> m_select = new List<ActorDef>();

    public void Update()
    {
        if (GameLogic.GetInstance.GetGameData().ioState == IO_STATE.InGame)
        {
            if(bFirst == true)
            {
                for (int i = 0; i < GameSetting.PLAYER_MAXIMUM; i++)
                    ClosePlayerIcon(i, ActorDef.Dad);
                PlayerUIData[] data = GameLogic.GetInstance.GetGameData().playerUIDatas;
                for (int i = 0; i < data.Length; i++)
                {
                    ActorDef actor = (ActorDef)data[i].uiPos;
                    SetPlayerIcon(i, actor);
                }
                SetQuestion(GetQuestionID());
                GameLogic.GetInstance.GetGamePlayerManager().dialog.Play_Show();
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
                        GameLogic.GetInstance.GetGamePlayerManager().dialog.Play_Close();
                        m_chooseState = ChooseState.End;
                    }
                    Debug.Log("ChooseState.WaitOther");
                    break;

                case ChooseState.End:
                    int answer = 0;

                    Dictionary<int, int> selectList = new Dictionary<int, int>();

                    foreach (PlayerController player in playerList)
                    {
                        if (player.m_playerID >= GameLogic.GetInstance.GetGameData().playerCount)
                            continue;
                        switch(player.m_selectID)
                        {
                            case 0:
                                answer = TableData.Init.GetEventTableData(GameSetting.CurEventID).ChooseID1;
                                break;
                            case 1:
                                answer = TableData.Init.GetEventTableData(GameSetting.CurEventID).ChooseID2;
                                break;
                            case 2:
                                answer = TableData.Init.GetEventTableData(GameSetting.CurEventID).ChooseID3;
                                break;
                        }
                        selectList.Add(player.m_playerID, answer);
                    }
                    int rndPlayerID = UnityEngine.Random.Range(0, GameLogic.GetInstance.GetGameData().playerCount);
                    int finalAnswer = selectList[rndPlayerID];

                    Debug.Log("finalAnswer: " + finalAnswer);

                    int life = TableData.Init.GetChooseTableData(finalAnswer).ChangeFeel;
                    int money = TableData.Init.GetChooseTableData(finalAnswer).ChangeMoney;
                    int quality = TableData.Init.GetChooseTableData(finalAnswer).ChangeQuality;

                    Debug.Log("life: " + life);
                    Debug.Log("money: " + money);
                    Debug.Log("quality: " + quality);
                    GameSetting.Life += life;
                    if (GameSetting.Life > 20)
                        GameSetting.Life = 20;
                    else if (GameSetting.Life < 0)
                        GameSetting.Life = 0;
                    GameSetting.Money += money;
                    if (GameSetting.Money > 20)
                        GameSetting.Money = 20;
                    else if (GameSetting.Money < 0)
                        GameSetting.Money = 0;
                    GameSetting.Quality += quality;
                    if (GameSetting.Quality > 20)
                        GameSetting.Quality = 20;
                    else if (GameSetting.Quality < 0)
                        GameSetting.Quality = 0;

                    // every time money add
                    GameSetting.Money++;

                    stateList.SetLife(GameSetting.Life);
                    stateList.SetMoney(GameSetting.Money);
                    stateList.SetQuality(GameSetting.Quality);


                    m_questionState = (QuestionState) TableData.Init.GetChooseTableData(finalAnswer).OpenEventNID;
                    m_questionState = QuestionState.Develop;

                    foreach (PlayerController player in playerList)
                    {
                        player.bSelected = false;
                    }
                    GameSetting.ChooseCount--;

                    m_chooseState = ChooseState.ShowItem;

                    ItemPutType itemType = TableData.Init.GetChooseTableData(finalAnswer).ItemType;

                    itemType = (ItemPutType)(DateTime.Now.Millisecond % 6);

                    switch (itemType)
                    {
                        case ItemPutType.Bookcase:
                            dicBGLevelValue[BG_LevelUp_Item.Bookcase]++;
                            dicBGLevelUp[BG_LevelUp_Item.Bookcase].LevelUp(dicBGLevelValue[BG_LevelUp_Item.Bookcase]);
                            break;
                        case ItemPutType.Lamp:
                            dicBGLevelValue[BG_LevelUp_Item.Lamp]++;
                            dicBGLevelUp[BG_LevelUp_Item.Lamp].LevelUp(dicBGLevelValue[BG_LevelUp_Item.Lamp]);
                            break;
                        case ItemPutType.Photo:
                            dicBGLevelValue[BG_LevelUp_Item.Photo]++;
                            dicBGLevelUp[BG_LevelUp_Item.Photo].LevelUp(dicBGLevelValue[BG_LevelUp_Item.Photo]);
                            break;
                        case ItemPutType.Sofa:
                            dicBGLevelValue[BG_LevelUp_Item.Sofa]++;
                            dicBGLevelUp[BG_LevelUp_Item.Sofa].LevelUp(dicBGLevelValue[BG_LevelUp_Item.Sofa]);
                            break;
                        case ItemPutType.Table:
                            dicBGLevelValue[BG_LevelUp_Item.Table]++;
                            dicBGLevelUp[BG_LevelUp_Item.Table].LevelUp(dicBGLevelValue[BG_LevelUp_Item.Table]);
                            break;
                    }
                    //foreach (KeyValuePair<BG_LevelUp_Item, BGLevelUp> obj in dicBGLevelUp)
                    //{
                    //    dicBGLevelValue[obj.Key]++;
                    //    obj.Value.LevelUp(dicBGLevelValue[obj.Key]);
                    //}

                    thisAnswer = finalAnswer;

                    Debug.Log("ChooseState.End");
                    break;
                case ChooseState.ShowItem:

                    if(curShowItemTime <= ShowItemTimer)
                    {
                        curShowItemTime += Time.deltaTime;
                        break;
                    }
                    curShowItemTime = 0.0f;

                    if (CheckIsOver() == false)
                    {
                        m_chooseState = ChooseState.WaitOther;
                        SetQuestion(GetQuestionID());
                        ResetPlayerSelect();
                        GameLogic.GetInstance.GetGamePlayerManager().dialog.Play_Show();
                    }
                    else
                    {
                        m_chooseState = ChooseState.GameOver;
                        stateList.gameObject.SetActive(false);
                        foreach (PlayerController player in playerList)
                        {
                            player.gameObject.SetActive(false);
                        }
                    }
                    break;
                case ChooseState.GameOver:
                    Debug.LogError("Game Over!!!");
                    GameLogic.GetInstance.GetGamePlayerManager().ShowRecord();
                    GameLogic.GetInstance.GetGameData().ioState = IO_STATE.Over;
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

            case RegistType.DialogController:
                dialog = (DialogController)r_object;
                break;
            case RegistType.BGLevelUpController:
                BGLevelUp obj = (BGLevelUp)r_object;
                BG_LevelUp_Item thisItem = (BG_LevelUp_Item)Enum.Parse(typeof(BG_LevelUp_Item), obj.name);
                dicBGLevelUp.Add(thisItem, obj);
                dicBGLevelValue.Add(thisItem, 1);
                break;
            case RegistType.RecordController:
                m_clsRecordController = r_object as RecordController;
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

    bool CheckIsOver()
    {
        if (GameSetting.Life <= 0)
            return true;
        if (GameSetting.Life >= 20)
            return true;
        if (GameSetting.Quality <= 0)
            return true;
        if (GameSetting.Quality >= 20)
            return true;
        if (GameSetting.Money <= 0)
            return true;
        if (GameSetting.Money >= 20)
            return true;
        if (GameSetting.ChooseCount <= 0)
            return true;
        return false;
    }


    public void SetPlayerIcon(int PlayerID, Common.ActorDef actor)
    {
        Debug.Log("playerList" + playerList.Count);
        Debug.Log("PlayerID" + PlayerID);
        Debug.Log("actor" + actor.ToString());
        playerList[PlayerID].ChangeActor(actor);
    }

    public void ClosePlayerIcon(int PlayerID, Common.ActorDef actor)
    {
        playerList[PlayerID].CloseActor(actor);
    }

    public void SetPlayerSelect(int PlayerID, int selectIndex)
    {
        playerList[PlayerID].SelectItem(selectIndex);
    }

    void ResetPlayerSelect()
    {
        for (int i = 0; i < playerList.Count; i++)
            playerList[i].SelectItem(-1);
    }

    public void PlayerIOCommand(int v_playerID, IO_Command r_ioCommand)
    {
        Debug.Log("v_playerID: " + v_playerID);
        Debug.Log("IO_Command: " + r_ioCommand.ToString());
        PlayerController player = playerList[v_playerID];

        if (m_chooseState != ChooseState.WaitOther)
            return;
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
        GameSetting.CurEventID = eventID;
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
        questionID = UnityEngine.Random.Range(0, 5);
        return questionID;
        switch (m_questionState)
        {
            case QuestionState.Demo:
                questionID = 0;
                break;
            case QuestionState.Creator:
                questionID = UnityEngine.Random.Range((int)QuestionEndID.Demo, (int)QuestionEndID.Creator)+1;
                break;
            case QuestionState.Develop:
                questionID = UnityEngine.Random.Range((int)QuestionEndID.Creator, (int)QuestionEndID.Develop)+1;
                break;
            case QuestionState.Fight:
                questionID = UnityEngine.Random.Range((int)QuestionEndID.Develop, (int)QuestionEndID.Fight)+1;
                break;
            default:
                questionID = UnityEngine.Random.Range((int)QuestionEndID.Demo, (int)QuestionEndID.Fight)+1;
                break;
        }
        return questionID;
    }

    public void ShowRecord()
    {
        m_clsRecordController.ShowRecord(); 
    }
}
