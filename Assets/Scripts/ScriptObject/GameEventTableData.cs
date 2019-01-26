using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   
public class GameEventTableData
{
    /// <summary>
    /// NID
    /// </summary>
    public int NID;
    /// <summary>
    /// 卡組號碼
    /// </summary>
    public int CardID;
    /// <summary>
    /// 事件明稱
    /// </summary>
    public string EventName;
    /// <summary>
    /// 選擇1
    /// </summary>
    public int ChooseID1;
    /// <summary>
    /// 選擇2
    /// </summary>
    public int ChooseID2;
    /// <summary>
    /// 選擇3
    /// </summary>
    public int ChooseID3;
}
