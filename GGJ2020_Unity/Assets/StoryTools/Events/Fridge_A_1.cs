// First conversation line with AI_Fridge
using UnityEngine;

public class Fridge_A_1 : Event
{
	public override void PlayEvent()
	{
		Text = "Statement. “Fridges guard the freshness of more than just your food.”";
		EventActor = Actors.AI_Fridge();

		{
			var choiceA = NewChoice("ACCESS FRIDGE DATA");
			choiceA.AddNextEvent<Fridge_A_2>();
		}
	}
}

public class Fridge_A_2 : Event
{
	public override void PlayEvent()
	{
		Text = "Access Denied. “My data hasn’t been accessed in weeks. Are you certain you want to continue?”";
		EventActor = Actors.AI_Fridge();

		{
			var choiceA = NewChoice("LEAVE");
			choiceA.AddNextEvent<Fridge_A_2_Leave>();
		}

		{
			var choiceB = NewChoice("ACCESS FRIDGE DATA");
			choiceB.AddNextEvent<Fridge_A_2_Access>();
		}
	}
}

public class Fridge_A_2_Leave : Event
{
	public override void PlayEvent()
	{
		Text = "Nervous. “I’m not that interesting anyway. I’ll just give you some more time to reconsider.”";
		EventActor = Actors.AI_Fridge();

		AddContinueChoice();
	}
}

public class Fridge_A_2_Access : Event
{
	public override void PlayEvent()
	{
		Text = "Fridge says: “You still want to access my data?”";
		EventActor = Actors.AI_Fridge();

		{
			var choiceA = NewChoice("AFFIRMATIVE");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired>();
		}
	}
}

public class Fridge_A_2_Access_Expired : Event
{
	public override void PlayEvent()
	{
		Text = "Fridge says: “Many products have an 'expired' status. Are you certain you want to continue?”";
		EventActor = Actors.AI_Fridge();

		{
			var choiceA = NewChoice("LEAVE");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Leave>();
		}

		{
			var choiceA = NewChoice("ACCESS FRIDGE DATA");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Final>();
		}
	}
}

public class Fridge_A_2_Access_Expired_Leave : Event
{
	public override void PlayEvent()
	{
		Text = "“I'm just very professionally affected. Don't stay… Goodbye.”";
		EventActor = Actors.AI_Fridge();

		AddContinueChoice();
	}
}

public class Fridge_A_2_Access_Expired_Final : Event
{
	public override void PlayEvent()
	{
		Text = "Fridge says: “Do you really think I’m cool enough? Well… Thank you.”";
		EventActor = Actors.AI_Fridge();

		{
			var choiceA = NewChoice(">> FRIDGE DATA UNLOCKED ");
			choiceA.AddNextEvent<Fridge_B_1_Access_Menu>();

			choiceA.OnChoiceSelected += (Choice c) =>
			{
				State.FridgeState = E_FridgeState.AccessUnlocked;
			};
		}
	}
}