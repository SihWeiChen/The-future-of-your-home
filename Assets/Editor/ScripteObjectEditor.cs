using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScripteObjectEditor : EditorWindow
{
    string path = "Assets/Resources/Data/GameEventAssset.asset";
    GameEventList eventList;

    string path2 = "Assets/Resources/Data/GameChooseAssset.asset";
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
            List<GameEventTableData> eventTables = new List<GameEventTableData>();
            eventTables.Add(new GameEventTableData());
            AssetDatabase.CreateAsset(eventList, path);
            AssetDatabase.SaveAssets();
        }

        if (GUILayout.Button("Create Choose"))
        {
            eventList2 = ScriptableObject.CreateInstance<GameChooseList>();
            List<GameChooseTableData> eventTables = new List<GameChooseTableData>();
            eventTables.Add(new GameChooseTableData());
            AssetDatabase.CreateAsset(eventList2, path2);
            AssetDatabase.SaveAssets();
        }

        if (GUILayout.Button("Add event"))
        {
            eventList.gameEventTables.Add(new GameEventTableData());
            EditorUtility.SetDirty(eventList);
        }
        if (GUILayout.Button("Add choose"))
        {
            eventList2.chooseTablesList.Add(new GameChooseTableData());
            //eventList2.chooseTablesList.Add(rtableData);
            EditorUtility.SetDirty(eventList2);
        }
        if (GUILayout.Button("Save"))
        {
            foreach (var item in eventList.gameEventTables)
            {
                Debug.Log(item.EventName);
            }
            EditorUtility.SetDirty(eventList);
            EditorUtility.SetDirty(eventList2);
        }
        if (GUI.changed) {
            EditorUtility.SetDirty(eventList);
            EditorUtility.SetDirty(eventList2);
        }
    }
}
