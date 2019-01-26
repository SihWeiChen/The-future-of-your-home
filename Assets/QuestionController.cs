using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Text m_Question;
    // Start is called before the first frame update
    void Start()
    {
        GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.QuestionController, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestionString(string value)
    {
        m_Question.text = value;
    }
}
