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

        public GameObject m_SelectGroup;

        public Image m_Select1;
        public Animation selectAni1;
        public Image m_Select2;
        public Animation selectAni2;
        public Image m_Select3;
        public Animation selectAni3;

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
        }

        public void ChangeActor(Common.ActorDef actor)
        {
            m_ActorIMG.sprite = SpriteManager.GetInstance().GetActorSprite(actor);
            m_ActorIMG.color = Color.white;
            m_SelectGroup.SetActive(true);
        }

        public void CloseActor(Common.ActorDef actor)
        {
            m_ActorIMG.sprite = SpriteManager.GetInstance().GetActorSprite(actor);
            m_ActorIMG.color = Color.gray;
            m_SelectGroup.SetActive(false);
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
                selectAni1.Play("ChooseDone");
                selectAni2.Play("ChooseDone");
                selectAni3.Play("ChooseDone");
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
                selectAni1.Play("BiliBili");
                selectAni2.Play("BiliBili");
                selectAni3.Play("BiliBili");
            }

            switch (m_selectID)
            {
                case 0:
                    m_Select1.gameObject.SetActive(true);
                    m_Select2.gameObject.SetActive(false);
                    m_Select3.gameObject.SetActive(false);
                    break;
                case 1:
                    m_Select1.gameObject.SetActive(false);
                    m_Select2.gameObject.SetActive(true);
                    m_Select3.gameObject.SetActive(false);
                    break;
                case 2:
                    m_Select1.gameObject.SetActive(false);
                    m_Select2.gameObject.SetActive(false);
                    m_Select3.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
