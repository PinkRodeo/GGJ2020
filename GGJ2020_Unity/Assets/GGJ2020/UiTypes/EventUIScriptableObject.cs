using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EventUIScriptableObject : ScriptableObject
{

    [SerializeField]
    List<data> UiTypes;

    [System.Serializable]
    public class data
    {
        [SerializeField]
        public E_ActorCategory Target;

        [SerializeField]
        public Texture2D BackGround;

        [SerializeField]
        public Texture2D PersonColor;

        [SerializeField]
        public TMP_FontAsset font;

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
