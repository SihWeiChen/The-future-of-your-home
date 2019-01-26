using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScripteObjectEditor : EditorWindow
{
    string path = "Assets/GameData/GameEventAssset.asset";
    GameEventList eventList;

    string path2 = "Assets/GameData/GameChooseAssset.asset";
    GameChooseList eventList2;

    [MenuItem("Window/Data Defn Editor %#m")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(ScripteObjectEditor));
    }
    void OnEnable()
    {

        eventList = AssetDatabase.LoadAssetAtPath(path,
                             typeof(GameEventList)) as GameEventList;
        eventList2 = AssetDatabase.LoadAssetAtPath(path2,
                             typeof(GameChooseList)) as GameChooseList;
    }

    void OnGUI()
    {
        if (GUILayout.Button("Load"))
        {
            eventList = AssetDatabase.LoadAssetAtPath(path,
                         typeof(GameEventList)) as GameEventList;
            eventList2 = AssetDatabase.LoadAssetAtPath(path2,
                                 typeof(GameChooseList)) as GameChooseList;
        }
        if (GUILayout.Button("Create EventTabList"))
        {
            eventList = ScriptableObject.CreateInstance<GameEventList>();
            eventList.gameEventTables = new List<GameEventTableData>();
            GameEventTableData newData = new GameEventTableData();
            newData.NID = eventList.gameEventTables.Count;
            eventList.gameEventTables.Add(newData);
            AssetDatabase.CreateAsset(eventList, path);
           //AssetDatabase.SaveAssets();
        }


        if (GUILayout.Button("Create Choose"))
        {
            eventList2 = ScriptableObject.CreateInstance<GameChooseList>();
            eventList2.chooseTablesList = new List<GameChooseTableData>();
            GameChooseTableData newData = new GameChooseTableData();
            newData.NID = eventList2.chooseTablesList.Count;
            eventList2.chooseTablesList.Add(newData);
            AssetDatabase.CreateAsset(eventList2, path2);
            AssetDatabase.SaveAssets();
        }

        if (GUILayout.Button("Add event"))
        {
            GameEventTableData newData = new GameEventTableData();
            newData.NID = eventList2.chooseTablesList[eventList2.chooseTablesList.Count-1].NID+1;
            eventList.gameEventTables.Add(newData);
            EditorUtility.SetDirty(eventList);
        }
        if (GUILayout.Button("Add choose"))
        {
            GameChooseTableData newData = new GameChooseTableData();
            newData.NID = eventList2.chooseTablesList[eventList2.chooseTablesList.Count-1].NID+1;
            eventList2.chooseTablesList.Add(newData);
            EditorUtility.SetDirty(eventList2);
        }
        if (GUILayout.Button("Save"))
        {
            List<GameEventTableData> eventTables = eventList.gameEventTables;
            EditorUtility.SetDirty(eventList);
            EditorUtility.SetDirty(eventList2);

        }
        if (GUI.changed) {
            EditorUtility.SetDirty(eventList);
            EditorUtility.SetDirty(eventList2);
        }
    }
}
