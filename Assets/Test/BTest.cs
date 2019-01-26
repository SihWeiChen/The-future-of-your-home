using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TableData.Init.GetEventTableData(1).EventName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
