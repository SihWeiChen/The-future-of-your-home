using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class SelectActorController : MonoBehaviour
    {
        int curSpriteIndex = 0;
        Sprite[] arySourceSprite;
        Image m_Image;

        public SelectActorManager manager;

        // Update is called once per frame
        void Update()
        {
            ChangeActor(curSpriteIndex);
        }

        public void ChangeActor(Common.ActorDef actor)
        {
            int index = (int)actor;
            ChangeActor(index);
        }
        public void ChangeActor(int index)
        { 
            curSpriteIndex = index;
            m_Image.sprite = arySourceSprite[curSpriteIndex];
        }
    }
}
