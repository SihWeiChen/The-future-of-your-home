using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableData : singlebase<TableData>
{
    string path = "GameData/GameEventAssset";
    GameEventList eventList;
    //Resources.Load<AllRooms>("ScriptObjects/Rooms/RoomCache/CachedRooms");
    string path2 = "GameData/GameChooseAssset";
    GameChooseList eventList2;

    public GameEventTableData GetEventTableData(int nid){
        if(eventList==null)
            eventList = Resources.Load<GameEventList>(path); 
        //Resources.Load(path,typeof(GameEventList)) as GameEventList;
        if (eventList.gameEventTables.Count < nid)
            return null;
        foreach (var item in eventList.gameEventTables)
        {
            if (item.NID == nid)
                return item;
        }
        return null;
    }

    public GameChooseTableData GetChooseTableData(int nid)
    {
        if (eventList2 == null)
            eventList2 = Resources.Load<GameChooseList>(path2);
        //Resources.Load(path2,
        //typeof(GameChooseList)) as GameChooseList;
        if (eventList2.chooseTablesList.Count < nid)
            return null;
        foreach (var item in eventList2.chooseTablesList)
        {
            if (item.NID == nid)
                return item;
        }
        return null;
    }
}
