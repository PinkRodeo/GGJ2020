// First conversation line with AI_Trashcan
using UnityEngine;

public class Trashcan_A_1 : Event
{
	public override void PlayEvent()
	{
		Text = "Statement. “One man's trash is another man's come-up.”";
		EventActor = Actors.AI_Trashcan();

		{
			var choiceA = NewChoice("PEEL OPEN THE LID");
			choiceA.AddNextEvent<Trashcan_A_2>();
		}
	}
}

public class Trashcan_A_2 : Event
{
	public override void PlayEvent()
	{
		Text = "“Hey man you don't wanna do that!”";
		EventActor = Actors.AI_Trashcan();

		{
			var choiceA = NewChoice("LEAVE");
			choiceA.AddNextEvent<Trashcan_A_2_Leave>();
		}

		{
			var choiceB = NewChoice("CONTINUE PEELING THE LID");
			choiceB.AddNextEvent<Trashcan_A_2_Access>();
		}
	}
}

public class Trashcan_A_2_Leave : Event
{
	public override void PlayEvent()
	{
		Text = "“Yeah you walk away! You know what's best for you!”";
		EventActor = Actors.AI_Trashcan();

		AddContinueChoice();
	}
}

public class Trashcan_A_2_Access : Event
{
	public override void PlayEvent()
	{
		Text = "“I'm warning you man!”";
		EventActor = Actors.AI_Trashcan();

		{
			var choiceA = NewChoice("FINALLY PEEL THE LID OPEN");
			choiceA.AddNextEvent<Trashcan_A_2_Opened>();
		}
	}
}

public class Trashcan_A_2_Opened : Event
{
	public override void PlayEvent()
	{
		Text = "“This here's your own risk man. I ain't warning you again.”";
		EventActor = Actors.AI_Trashcan();

		{
			var choiceA = NewChoice("LEAVE");
			choiceA.AddNextEvent<Trashcan_A_2_Opened_Leave>();
		}

		{
			var choiceA = NewChoice("PEEK INSIDE");
			choiceA.AddNextEvent<Trashcan_A_2_Opened_Final>();
		}
	}
}

public class Trashcan_A_2_Opened_Leave : Event
{
	public override void PlayEvent()
	{
		Text = "“Oh you... you don't want... to peek? Okay...”";
		EventActor = Actors.AI_Trashcan();

		AddContinueChoice();
	}
}

public class Trashcan_A_2_Opened_Final : Event
{
	public override void PlayEvent()
	{
		Text = "“Do you really think I’m cool enough? Well… Thank you.”";
		EventActor = Actors.AI_Trashcan();

		{
			var choiceA = NewChoice(">> TRASHCAN DATA UNLOCKED ");
			choiceA.AddNextEvent<Trashcan_B_1_Inventory>();

			choiceA.OnChoiceSelected += (Choice c) =>
			{
				State.TrashcanState = E_TrashcanState.AccessUnlocked;
			};
		}
	}
}
