using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager m_Instance = null;

    public Sprite m_Dad;
    public Sprite m_Mom;
    public Sprite m_Daughter;
    public Sprite m_Son;

    public Sprite m_ItemCar;
    public Sprite m_ItemBook;
    public Sprite m_ItemPS4;
    public Sprite m_ItemHat;

    public static SpriteManager GetInstance()
    {
        return m_Instance;
    }
    // Start is called before the first frame update
    void Awake()
    {
        m_Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetActorSprite(Common.ActorDef actor)
    {
        Sprite temp = m_Dad;
        switch (actor)
        {
            case Common.ActorDef.Dad:
                temp = m_Dad;
                break;
            case Common.ActorDef.Mom:
                temp = m_Mom;
                break;
            case Common.ActorDef.Son:
                temp = m_Son;
                break;
            case Common.ActorDef.Daughter:
                temp = m_Daughter;
                break;
        }
        return temp;
    }

    public Sprite GetItemSprite(Common.EventItem item)
    {
        Sprite temp = m_ItemCar;
        switch(item)
        {
            case Common.EventItem.Book:
                temp = m_ItemBook;
                break;
            case Common.EventItem.Car:
                temp = m_ItemCar;
                break;
            case Common.EventItem.Hat:
                temp = m_ItemHat;
                break;
            case Common.EventItem.PS4:
                temp = m_ItemPS4;
                break;
        }
        return temp;
    }
}
