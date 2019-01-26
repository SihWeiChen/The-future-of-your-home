using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTest : MonoBehaviour
{
    public bool Up;
    public int EventNid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Up){
            Debug.Log(TableData.Init.GetEventTableData(EventNid).EventName);
            Up = false;
        }
    }
}
