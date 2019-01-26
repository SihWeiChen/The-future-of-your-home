using UnityEngine;

using UnityEditor;
using System.Collections.Generic;


public class MonsterDefnEditor : EditorWindow
{
    string path = "Assets/Resources/Data/GameEventAssset.asset";
    GameEventList  eventList;

    [MenuItem("Window/Data Defn Editor %#m")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(MonsterDefnEditor));
    }

    void OnEnable()
    {
        eventList = AssetDatabase.LoadAssetAtPath(path,
                            typeof(GameEventList)) as GameEventList;
    }

    void OnGUI()
    {
        if (GUILayout.Button("Create New List"))
        {
            eventList = ScriptableObject.CreateInstance<GameEventList>();
            List<GameEventTable> eventTables = new List<GameEventTable>();
            AssetDatabase.CreateAsset(eventList, path);
            AssetDatabase.SaveAssets();
        }

        if (GUI.changed) EditorUtility.SetDirty(eventList);
    }
}

