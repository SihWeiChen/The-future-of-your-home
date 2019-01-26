using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TableData : singlebase<TableData>
{
    string path = "Assets/GameData/GameEventAssset.asset";
    GameEventList eventList;

    string path2 = "Assets/GameData/GameChooseAssset.asset";
    GameChooseList eventList2;

    public GameEventTableData GetEventTableData(int nid){
        if(eventList==null)
            eventList = AssetDatabase.LoadAssetAtPath(path,
                             typeof(GameEventList)) as GameEventList;
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
            eventList2 = AssetDatabase.LoadAssetAtPath(path2,
                             typeof(GameChooseList)) as GameChooseList;
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
