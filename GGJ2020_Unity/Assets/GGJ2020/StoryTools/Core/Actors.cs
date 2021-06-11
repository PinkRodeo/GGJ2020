using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public E_ActorCategory ActorCategory;
    public E_ActorType ActorType;

    public Color Tint;

    public string Name;

    public Actor(E_ActorCategory actorCategory, E_ActorType actorType, Color tint, string name)
    {
        ActorCategory = actorCategory;
        ActorType = actorType;
        Tint = tint;
        Name = name;
    }

}

public enum E_ActorCategory
{
    World,
    AI,
    Phone,
}

public enum E_ActorType
{
    World,

    // AI
    AI_Alinna,
    AI_BaseStation,
    AI_Fridge,
    AI_Plant_Fern,
    AI_Plant_Planto,
    AI_Plant_Blini,
    AI_Plant_Eddie,
    AI_Plant_Niels,
    AI_Trashcan,

    // Config
    Phone_Scott,
    Phone_Jen,
    Phone_Intercom,

    Headset,
    Capsules,
    AI_Shoes,
    AI_Vape,
}

public static class Actors
{
    private static Actor _World;
    public static Actor World()
    {
        if (_World == null)
        {
            _World = new Actor(E_ActorCategory.World,
                            E_ActorType.World,
                            Color.magenta,
                            "");
        }

        return _World;
    }

    private static Actor _AI_Alinna;
    public static Actor AI_Alinna()
    {
        if (_AI_Alinna == null)
        {
            _AI_Alinna = new Actor(E_ActorCategory.World,
                            E_ActorType.AI_Alinna,
                            Color.magenta,
                            "▼ AlinnaOS");
        }

        return _AI_Alinna;
    }

    private static Actor _AI_BaseStation;
    public static Actor AI_BaseStation()
    {
        if (_AI_BaseStation == null)
        {
            _AI_BaseStation = new Actor(E_ActorCategory.Phone,
                            E_ActorType.AI_BaseStation,
                            new Color(0.321f, 0.650f, 1f, 0.9f),
                            "■ Taango Base Station");
        }

        return _AI_BaseStation;
    }

    private static Actor _AI_Fridge;
    public static Actor AI_Fridge()
    {
        if (_AI_Fridge == null)
        {
            _AI_Fridge = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Fridge,
                            new Color(0.415f, 0.925f, 0.623f, 0.9f),
                            "● Fridger 2.0");
        }

        return _AI_Fridge;
    }

    private static Actor _AI_Trashcan;
    public static Actor AI_Trashcan()
    {
        if (_AI_Trashcan == null)
        {
            _AI_Trashcan = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Trashcan,
                            Color.magenta,
                            "● Trashy the trashcan");
        }

        return _AI_Trashcan;
    }

    private static Actor _AI_Plant_Fern;
    public static Actor AI_Plant_JULES_FERN()
    {
        if (_AI_Plant_Fern == null)
        {
            _AI_Plant_Fern = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Plant_Fern,
                            new Color(0.415f, 0.925f, 0.623f, 0.9f),
                            "● Jules Fern");
        }

        return _AI_Plant_Fern;
    }

    private static Actor _AI_Plant_Eddie;
    public static Actor AI_Plant_EDDIE_LEAFLY()
    {
        if (_AI_Plant_Eddie == null)
        {
            _AI_Plant_Eddie = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Plant_Eddie,
                            new Color(0.415f, 0.925f, 0.623f, 0.9f),
                            "● Eddie Leafly");
        }

        return _AI_Plant_Eddie;
    }

    private static Actor _AI_Plant_Niels;
    public static Actor AI_Plant_NIELS()
    {
        if (_AI_Plant_Niels == null)
        {
            _AI_Plant_Niels = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Plant_Niels,
                            new Color(0.415f, 0.925f, 0.623f, 0.9f),
                            "● Sucratus");
        }

        return _AI_Plant_Niels;
    }

    private static Actor _AI_Plant_Planto;

    public static Actor AI_Plant_PLANTO()
    {
        if (_AI_Plant_Planto == null)
        {
            _AI_Plant_Planto = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Plant_Planto,
                            new Color(0.415f, 0.925f, 0.623f, 0.9f),
                            "● Planto");
        }

        return _AI_Plant_Planto;
    }

    private static Actor _AI_Plant_Blini;

    public static Actor AI_Plant_BLINI()
    {
        if (_AI_Plant_Blini == null)
        {
            _AI_Plant_Blini = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Plant_Blini,
                            new Color(0.415f, 0.925f, 0.623f, 0.9f),
                            "● Blini");
        }

        return _AI_Plant_Blini;
    }

    private static Actor _Phone_Scott;
    public static Actor Phone_Scott()
    {
        if (_Phone_Scott == null)
        {
            _Phone_Scott = new Actor(E_ActorCategory.Phone,
                            E_ActorType.Phone_Scott,
                            Color.magenta,
                            "■ Scott's Phone");
        }

        return _Phone_Scott;
    }

    private static Actor _Phone_Intercom;
    public static Actor Phone_Intercom()
    {
        if (_Phone_Intercom == null)
        {
            _Phone_Intercom = new Actor(E_ActorCategory.AI,
                            E_ActorType.Phone_Intercom,
                            Color.magenta,
                            "● Intercom");
        }

        return _Phone_Intercom;
    }

    private static Actor _Shoes;
    public static Actor Shoes()
    {
        if (_Shoes == null)
        {
            _Shoes = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Shoes,
                            new Color(0.415f, 0.925f, 0.623f, 0.9f),
                            "● Scott's Shoes");
        }

        return _Shoes;
    }

    private static Actor _Vape;
    public static Actor Vape()
    {
        if (_Vape == null)
        {
            _Vape = new Actor(E_ActorCategory.AI,
                            E_ActorType.AI_Vape,
                            new Color(0.192f, 0.545f, 0.749f),
                            "● Jen's Vape");
        }

        return _Vape;
    }

    private static Actor _Phone_Jen;
    public static Actor Phone_Jen()
    {
        if (_Phone_Jen == null)
        {
            _Phone_Jen = new Actor(E_ActorCategory.Phone,
                            E_ActorType.Phone_Jen,
                            Color.magenta,
                            "■ Jen's Phone");
        }

        return _Phone_Jen;
    }


    private static Actor _Headset;
    public static Actor Headset()
    {
        if (_Headset == null)
        {
            _Headset = new Actor(E_ActorCategory.Phone,
                            E_ActorType.Headset,
                            Color.magenta,
                            "■ Glass VR");
        }

        return _Headset;
    }

    private static Actor _Capsules;
    public static Actor Capsules()
    {
        if (_Capsules == null)
        {
            _Capsules = new Actor(E_ActorCategory.AI,
                            E_ActorType.Capsules,
                            Color.magenta,
                            "■ Cappy Capsules");
        }

        return _Capsules;
    }
}
