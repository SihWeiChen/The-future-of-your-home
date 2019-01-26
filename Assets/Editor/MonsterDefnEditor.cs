using UnityEngine;

using UnityEditor;
using System.Collections.Generic;


public class MonsterDefnEditor : EditorWindow
{
    string path = "Assets/Resources/Data/GameEventAssset.asset";
    GameEventList  eventList;

    string path2 = "Assets/Resources/Data/GameChooseAssset.asset";
    ChooseTableList eventList2;

    [MenuItem("Window/Data Defn Editor %#m")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(MonsterDefnEditor));
    }

    void OnEnable()
    {
        eventList = AssetDatabase.LoadAssetAtPath(path,
                            typeof(GameEventList)) as GameEventList;
        eventList2 = AssetDatabase.LoadAssetAtPath(path2,
                          typeof(ChooseTableList)) as ChooseTableList;
    }

    void OnGUI()
    {
        if (GUILayout.Button("Create EventTabList"))
        {
            eventList = ScriptableObject.CreateInstance<GameEventList>();
            List<GameEventTable> eventTables = new List<GameEventTable>();
            AssetDatabase.CreateAsset(eventList, path);
            AssetDatabase.SaveAssets();
        }
        if (GUILayout.Button("Create Chose"))
        {
            eventList2 = ScriptableObject.CreateInstance<ChooseTableList>();
            List<ChooseTableList> eventTables = new List<ChooseTableList>();
            AssetDatabase.CreateAsset(eventList2, path2);
            AssetDatabase.SaveAssets();
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(eventList);
            EditorUtility.SetDirty(eventList2);
        }
    }
}
