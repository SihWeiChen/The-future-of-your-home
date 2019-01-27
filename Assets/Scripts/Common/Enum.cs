using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class GameSetting
    {
        public static int PLAYER_MAXIMUM = 4;
        public static int Money = 10;
        public static int Quality = 10;
        public static int Life = 10;
        public static int ChooseCount = 10;
        public static int CurEventID = 0;
    }

    public enum ActorDef
    {
        Dad = 0,
        Mom = 1,
        Daughter = 2,
        Son = 3,
    }

    public class EventObject
    {
        public int m_EventID;
        public string m_EventName;
        public int m_Quality;
        public int m_Affection;
        public int m_Money;
        public List<int> m_OpenEvent;
        public EventObject(int eventID, string eventName, int quality, int affection, int money)
        {
            m_EventID = eventID;
            m_EventName = eventName;
            m_Quality = quality;
            m_Affection = affection;
            m_Money = money;
        }
    }

    public enum Param_STATE
    {
        Life,
        Quality,
        Money,
    }

    public enum IO_STATE
    {
        None = 0,
        SelectCharacter,
        Ready,
        InGame, 
    }

    public enum IO_Command
    {
        A = 0,
        B,
        C,
        D,
        Up, 
        Down,
        Left,
        Right,
    }

    /// <summary>
    /// 物品放置類型
    /// </summary>
    public enum ItemPutType{
        None,
        Sofa,
        Table,
        Bookcase,
        Photo,
        Lamp,
    }

}
