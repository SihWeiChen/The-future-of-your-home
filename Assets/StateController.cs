using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateController : MonoBehaviour
{
    public Bar m_bars_Q; // qu
    public Bar m_bars_L; // life
    public Bar m_bars_M; // money

    public TextMeshPro m_Q_Value;
    public TextMeshPro m_L_Value;
    public TextMeshPro m_M_Value;
    // Start is called before the first frame update
    void Start()
    {
        SetQuality(0);
        SetLife(0);
        SetMoney(0);

        GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.StateController, this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetQuality(float value)
    {
        m_bars_Q.SetValue(value);
        m_Q_Value.text = value.ToString();
    }

    public void SetLife(float value)
    {
        m_bars_L.SetValue(value);
        m_L_Value.text = value.ToString();
    }

    public void SetMoney(float value)
    {
        m_bars_M.SetValue(value);
        m_M_Value.text = value.ToString();
    }

}
