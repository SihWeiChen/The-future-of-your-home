using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

using Controller;

public class SelectActorManager : MonoBehaviour
{
    public Controller.SelectActorController[] aryPlayerList;
    Dictionary<int, Common.ActorDef> m_Family = new Dictionary<int, ActorDef>(Common.GameSetting.PLAYER_MAXIMUM);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Init()
    {
        for(int i = 0;i  < aryPlayerList.Length;i++)
        {
            aryPlayerList[i].manager = this;
            Common.ActorDef thisActor = (ActorDef)i;
            aryPlayerList[i].ChangeActor(thisActor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
