using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public Bar m_bars_Q; // qu
    public Bar m_bars_L; // life
    public Bar m_bars_M; // money
    // Start is called before the first frame update
    void Start()
    {
        m_bars_Q.aaa(0);
        m_bars_L.aaa(0);
        m_bars_M.aaa(0);

        GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.StateController, this);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetQuality(float value)
    {
        m_bars_Q.aaa(value);
    }

    public void SetLife(float value)
    {
        m_bars_L.aaa(value);
    }

    public void SetMoney(float value)
    {
        m_bars_M.aaa(value);
    }

}
