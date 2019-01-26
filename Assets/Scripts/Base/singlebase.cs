using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Data Singleton
/// </summary>
public abstract class singlebase<Tscript> where Tscript : singlebase<Tscript> {
    private static Tscript singleT;
    public static Tscript Init {
        get{
            if (singleT == null)
            {
                singleT = Activator.CreateInstance<Tscript>();
               // singleT = new Tscript();
            }
              //  singleT = new Tscript();

            return singleT;
        }
    }
}

/// <summary>
/// MonoBehavie Singleton
/// </summary>
public abstract class singlebaseMono<Tscript>:MonoBehaviour where Tscript : singlebaseMono<Tscript>
{
    private static Tscript singleT;
    public static Tscript Init
    {
        get
        {
            
            if (singleT == null)
            {
                if (FindObjectOfType<Tscript>() == null)
                {
                    singleT = FindObjectOfType<Tscript>();
                }
                else
                {
                    singleT = Activator.CreateInstance<Tscript>();
                }
                Debug.Log("Null get one " + singleT.GetType().Name);
            }
              //  singleT = new Tscript();

            return singleT;
        }
    }
}

public abstract class UiVive<TScript>: singlebaseUiVive<TScript> where TScript  :UiVive<TScript>{

    public static bool OpenUI()
    {
        Init.OpenUILogicShowBefore();
        Init.OpenUILogicShowAfter();
        Debug.Log("Openend");
        return true;
    }
    public static bool CloseUI()
    {
        Init.CloseUILgic();
        return true;
    }


}

/// <summary>
/// UI介面 singleton
/// </summary>
/// 
public abstract class singlebaseUiVive<Tscript> : singlebaseMono<Tscript> where Tscript : singlebaseMono<Tscript>{
    protected bool OpenUILogicShowBefore(){
        UIReadyShowBefore();
        UIReadyShowAfter();
        return true;
    }
    protected bool OpenUILogicShowAfter()
    {
        UIShowBefore();
        UIShowAfter();
        return true;
    }
    protected bool CloseUILgic(){
        CloseUIBefore();
        CloseUIAfter();
        return true;
    }
    /// <summary>
    /// ＵＩ介面顯示前 第一階段
    /// </summary>
    virtual protected void UIReadyShowBefore(){}
    /// <summary>
    /// ＵＩ介面顯示前 第二階段
    /// </summary>
    virtual protected void UIReadyShowAfter(){ }

    /// <summary>
    /// Starts the before.
    /// </summary>
    virtual protected void UIShowBefore(){ }
    /// <summary>
    /// Starts the after.
    /// </summary>
    virtual protected void UIShowAfter(){ }

    /// <summary>
    /// Closes the before.
    /// </summary>
    virtual protected void CloseUIBefore(){ }
    /// <summary>
    /// Closes the after.
    /// </summary>
    virtual protected void CloseUIAfter(){ }
}

