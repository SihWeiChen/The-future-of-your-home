using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        Image m_ActorIMG;
        // Start is called before the first frame update
        void Start()
        {

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

        void ChangeActor(Common.ActorDef actor)
        {
            m_ActorIMG.sprite = SpriteManager.GetInstance().GetActorSprite(actor);
        }
    }
}
