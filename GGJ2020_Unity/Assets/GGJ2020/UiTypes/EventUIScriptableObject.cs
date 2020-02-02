using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======

>>>>>>> d6faeb2a3df59290fdf92404fdbb4d4ac943f121

public class EventUIScriptableObject : ScriptableObject
{

    [SerializeField]
    List<data> UiTypes;

    [System.Serializable]
    public class data
    {
        [SerializeField]
        public E_ActorCategory Target;

<<<<<<< HEAD
       // [SerializeField]
        //public Texture2D PersonColor;

        [SerializeField]
        public TMP_FontAsset font;

        [SerializeField]
        public Sprite TitleSprite;

        [SerializeField]
        public Sprite TextBoxSprite;

        [SerializeField]
        public Sprite DefaultSprite;

        [SerializeField]
        public Sprite PressedSprite;

        [SerializeField]
        public Sprite SelectedSprite;
=======
        [SerializeField]
        public Texture2D BackGround;

        [SerializeField]
        public Texture2D PersonColor;

        [SerializeField]
        public TMP_FontAsset font;
>>>>>>> d6faeb2a3df59290fdf92404fdbb4d4ac943f121

        [SerializeField]
        public TextAlignmentOptions alignment;

    }

    public data GetDataForCategory(E_ActorCategory category)
    {
        foreach (var item in UiTypes)
        {
            if (item.Target == category)
                return item;
        }
        return null;
    }


}
