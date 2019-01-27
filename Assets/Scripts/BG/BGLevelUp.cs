using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLevelUp : MonoBehaviour
{

    public OBJLevelUp[] LVGameObj;
    public int lv = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        this.LVGameObj = new OBJLevelUp[this.GetComponentsInChildren<OBJLevelUp>().Length];
        this.LVGameObj =this.GetComponentsInChildren<OBJLevelUp>();
        this.LevelUp();

        GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.BGLevelUpController, this);
    }


    public void LevelUp(int LV = 1)
    {
        if (LV > this.LVGameObj.Length)
        {
            LV = this.LVGameObj.Length;
        }else if (LV <= 0)
        {
            LV = 1;
        }

        for (int i = 0; i < this.LVGameObj.Length; i++)
        {
            if (this.LVGameObj[i].name == string.Format("LV{0}", LV))
            {
                this.LVGameObj[i].gameObject.SetActive(true);
            }
            else
            {
                this.LVGameObj[i].gameObject.SetActive(false) ;
            }
        }
    }
}
