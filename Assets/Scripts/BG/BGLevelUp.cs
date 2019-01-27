using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLevelUp : MonoBehaviour
{

    //public OBJLevelUp[] LVGameObj;
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        //this.LVGameObj = new OBJLevelUp[this.GetComponentsInChildren<OBJLevelUp>().Length];
        //this.LVGameObj =this.GetComponentsInChildren<OBJLevelUp>();
        this.animator = this.GetComponent<Animator>();
        this.LevelUp();


    }


    public void LevelUp(int LV = 1)
    {

        this.animator.SetInteger("LV", LV);

        //for (int i = 0; i < this.LVGameObj.Length; i++)
        //{
        //    if (this.LVGameObj[i].name == string.Format("LV{0}", LV))
        //    {
        //        this.LVGameObj[i].gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        this.LVGameObj[i].gameObject.SetActive(false) ;
        //    }
        //}
    }
}
