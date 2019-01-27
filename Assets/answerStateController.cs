using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answerStateController : MonoBehaviour
{
    public List<GameObject> objectPos;
    List<Vector3> objectListPos = new List<Vector3>();

    public GameObject objLife;
    public GameObject objQuality;
    public GameObject objMoney;

    public Sprite m_spriteUp;
    public Sprite m_spriteDown;

    public Image objLife_value;
    public Image objQuality_value;
    public Image objMoney_value;

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Start:" + objectPos.Count);
        for(int i = 0; i <objectPos.Count; i++)
        {
            objectListPos.Add(objectPos[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnswerState(int quality, int life, int money)
    {
        Debug.Log("quality: " + quality + ", life: " + life + ", money: " + money);
        int count = 0;
        Vector3 targetPos;

        targetPos = objectListPos[count];
        if (quality != 0)
        {
            objQuality.SetActive(true);
            //objQuality.transform.position = targetPos;
            if (quality > 0)
                objQuality_value.sprite = m_spriteUp;
            else
                objQuality_value.sprite = m_spriteDown;
            count++;
        }
        else
        {
            objQuality.SetActive(false);
        }

        targetPos = objectListPos[count];
        if (life != 0)
        {
            objLife.SetActive(true);
            //objLife.transform.position = targetPos;
            if (life > 0)
                objLife_value.sprite = m_spriteUp;
            else
                objLife_value.sprite = m_spriteDown;
            count++;
        }
        else
        {
            objLife.SetActive(false);
        }

        targetPos = objectListPos[count];
        if (money != 0)
        {
            objMoney.SetActive(true);
            //objMoney.transform.position = targetPos;
            if (money > 0)
                objMoney_value.sprite = m_spriteUp;
            else
                objMoney_value.sprite = m_spriteDown;
            count++;
        }
        else
        {
            objMoney.SetActive(false);
        }
    }
}
