using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        public int m_playerID;
        public Image m_ActorIMG;

        public Image m_Item1;
        public Image m_Item2;
        public Image m_Item3;
        // Start is called before the first frame update
        void Start()
        {
            GameLogic.GetInstance.GetGamePlayerManager().Regist(GamePlayManager.RegistType.PlayerController, this);
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

    }
}
