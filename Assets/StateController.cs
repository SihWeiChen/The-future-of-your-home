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

    [SerializeField] TextMeshPro m_tmpQulity;
    [SerializeField] TextMeshPro m_tmpLife;
    [SerializeField] TextMeshPro m_tmpMoney;
    [SerializeField] Animation m_animQuality;
    [SerializeField] Animation m_animLife;
    [SerializeField] Animation m_animMoney;

    void Start()
    {
        SetQuality(0, 0.0f);
        SetLife(0, 0.0f);
        SetMoney(0, 0.0f);
        m_tmpQulity.enabled = false;
        m_tmpLife.enabled = false;
        m_tmpMoney.enabled = false;
        GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.StateController, this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetQuality(float value, float v_extraValue)
    {
        m_bars_Q.SetValue(value);
        m_Q_Value.text = value.ToString();
        m_tmpQulity.text = v_extraValue < 0 ? "-" + v_extraValue.ToString() : "+" + v_extraValue.ToString();

        if (v_extraValue != 0)
        { 
            m_animQuality.Play();
            m_tmpQulity.enabled = true;
        }
    }

    public void SetLife(float value, float v_extraValue)
    {
        m_bars_L.SetValue(value);
        m_L_Value.text = value.ToString();
        m_tmpLife.text = v_extraValue < 0 ? "-" + v_extraValue.ToString() : "+" + v_extraValue.ToString();

        if (v_extraValue != 0)
        { 
            m_animLife.Play();
            m_tmpLife.enabled = true;
        }
    }

    public void SetMoney(float value, float v_extraValue)
    {
        m_bars_M.SetValue(value);
        m_M_Value.text = value.ToString();
        m_tmpMoney.text = v_extraValue < 0 ? "-" + v_extraValue.ToString() : "+" + v_extraValue.ToString();

        if (v_extraValue != 0)
        { 
            m_animMoney.Play();
            m_tmpMoney.enabled = true;
        }
    }

}
