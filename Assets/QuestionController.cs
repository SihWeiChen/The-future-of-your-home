using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Text m_Question;
    public Text m_Answer1;
    public Text m_Answer2;
    public Text m_Answer3;
    // Start is called before the first frame update
    void Start()
    {
        GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.QuestionController, this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.V))
        {
            int eventID = Random.Range(0, 21);
            //SetQuestionString(TableData.Init.GetEventTableData(eventID).EventName);
        }
    }

    public void SetQuestionString(string value, string an1, string an2, string an3)
    {
        m_Question.text = value;
        m_Answer1.text = an1;
        m_Answer2.text = an2;
        m_Answer3.text = an3;
    }
}
