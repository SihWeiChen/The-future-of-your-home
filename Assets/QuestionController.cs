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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.V))
        {
            int eventID = Random.Range(0, 21);
            //SetQuestionString(TableData.Init.GetEventTableData(eventID).EventName);
        }
    }

    public void SetQuestionString(string value)
    {
        m_Question.text = value;
    }
}
