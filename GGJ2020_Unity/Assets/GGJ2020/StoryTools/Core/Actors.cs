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
	AI_Trashcan,

	// Config
	Phone_Scott,
	Phone_Jen,

	Headset,
	Capsules,
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
							Color.white,
							"");
		}

		return _World;
	}

	private static Actor _AI_Alinna;
	public static Actor AI_Alinna()
	{
		if (_AI_Alinna == null)
		{
			_AI_Alinna = new Actor(E_ActorCategory.AI,
							E_ActorType.AI_Alinna,
							Color.magenta,
							"Alinna");
		}

		return _AI_Alinna;
	}

	private static Actor _AI_BaseStation;
	public static Actor AI_BaseStation()
	{
		if (_AI_BaseStation == null)
		{
			_AI_BaseStation = new Actor(E_ActorCategory.AI,
							E_ActorType.AI_BaseStation,
							Color.blue,
							"TAANGO Home Station");
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
							Color.white,
							"FIFO - Fridge");
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
							Color.white,
							"Trashy the trashcan");
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
							Color.green,
							"JULES FERN");
		}

		return _AI_Plant_Fern;
	}

	private static Actor _AI_Plant_Planto;

	public static Actor AI_Plant_PLANTO()
	{
		if (_AI_Plant_Planto == null)
		{
			_AI_Plant_Planto = new Actor(E_ActorCategory.AI,
							E_ActorType.AI_Plant_Planto,
							Color.green,
							"PLANTO");
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
							Color.green,
							"BLINI");
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
							Color.green,
							"Scott's Phone");
		}

		return _Phone_Scott;
	}

	private static Actor _Phone_Jen;
	public static Actor Phone_Jen()
	{
		if (_Phone_Jen == null)
		{
			_Phone_Jen = new Actor(E_ActorCategory.Phone,
							E_ActorType.Phone_Jen,
							Color.green,
							"Jen's Phone");
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
							Color.green,
							"VR GEAR THE GLASS");
		}

		return _Headset;
	}

	private static Actor _Capsules;
	public static Actor Capsules()
	{
		if (_Capsules == null)
		{
			_Capsules = new Actor(E_ActorCategory.Phone,
							E_ActorType.Capsules,
							Color.red,
							"E-CIG CAPSULES");
		}

		return _Capsules;
	}
}
