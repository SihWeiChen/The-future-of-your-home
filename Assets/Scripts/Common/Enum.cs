using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class GameSetting
    {
        public static int PLAYER_MAXIMUM = 4;
    }



    public enum ActorDef
    {
        Dad = 0,
        Mom = 1,
        Son = 2,
        Daughter = 3,
    }

    public class EventObject
    {
        public string eventName;
        public int Quality;
        public int Affection;
        public int Money;
        public List<int> openEvent;
    }

    public enum IO_STATE
    {
        None = 0,
        SelectCharacter,
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
}
