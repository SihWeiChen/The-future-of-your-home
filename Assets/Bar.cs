using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public SpriteRenderer Bar_1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            SetValue(50);       
    }
    //0~100
    public void SetValue(float b)
    {
        Bar_1.size = new Vector2(0.034f*b, 0.25f); 
    }
}
