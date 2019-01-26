using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        public int m_playerID;
        public int m_selectID;
        public Image m_ActorIMG;

        public Image m_Item1;
        public Image m_Item2;
        public Image m_Item3;

        public Image m_Select1;
        public Image m_Select2;
        public Image m_Select3;

        public bool bSelected = false;
        // Start is called before the first frame update
        void Awake()
        {
            SelectItem(-1);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                int test = Random.Range(0, 4);
                ChangeActor((Common.ActorDef)test);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                int test1 = Random.Range(0, 4);
                int test2 = Random.Range(0, 4);
                int test3 = Random.Range(0, 4);
                ChangeItem((Common.EventItem)test1, (Common.EventItem)test2, (Common.EventItem)test3);
            }
        }

        public void ChangeActor(Common.ActorDef actor)
        {
            m_ActorIMG.sprite = SpriteManager.GetInstance().GetActorSprite(actor);
        }

        public void ChangeItem(Common.EventItem item1, Common.EventItem item2, Common.EventItem item3)
        {
            m_Item1.sprite = SpriteManager.GetInstance().GetItemSprite(item1);
            m_Item2.sprite = SpriteManager.GetInstance().GetItemSprite(item2);
            m_Item3.sprite = SpriteManager.GetInstance().GetItemSprite(item3);
        }

        public int GetSelectIndex()
        {
            return m_selectID;
        }

        public void SelectItem(int cmd)
        {
            if (bSelected == true)
                return;
            if (cmd == 2)
            {
                bSelected = true;
                return;
            }
            if (cmd == 1)
            {
                if (m_selectID == 2)
                    return;
                    m_selectID++;
            }
            else if(cmd == 0)
            {
                if (m_selectID == 0)
                    return;
                m_selectID--;
            }
            else if(cmd == -1)
            {
                m_selectID = 0;
            }

            switch (m_selectID)
            {
                case 0:
                    m_Select1.enabled = true;
                    m_Select2.enabled = false;
                    m_Select3.enabled = false;
                    break;
                case 1:
                    m_Select1.enabled = false;
                    m_Select3.enabled = false;
                    m_Select2.enabled = true;
                    break;
                case 2:
                    m_Select3.enabled = true;
                    m_Select1.enabled = false;
                    m_Select2.enabled = false;
                    break;
            }
        }
    }
}
