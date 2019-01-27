using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameChooseTableData
{
    /// <summary>
    /// NID
    /// </summary>
    public int NID;
    /// <summary>
    /// 事件名稱
    /// </summary>
    public string ChooseName;
    /// <summary>
    /// 改變品質
    /// </summary>
    public int ChangeQuality;
    /// <summary>
    /// 改變感情
    /// </summary>
    public int ChangeFeel;
    /// <summary>
    /// 改變金錢
    /// </summary>
    public int ChangeMoney;
    public Common.ItemPutType ItemType;
    /// <summary>
    /// 開啟事件
    /// </summary>
    public int OpenEventNID;
}

