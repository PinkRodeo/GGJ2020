﻿// First conversation line with AI_Fridge

using UnityEngine;
public class Fridge_A_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Statement. “Fridges guard the freshness of more than just your food.”";
		ConversationActor = Actors.AI_Fridge();

        {
			var choiceA = NewEventChoice("ACCESS FRIDGE DATA");
			choiceA.AddNextEvent<Fridge_A_2>();
		}
    }
}

public class Fridge_A_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "Access Denied. “My data hasn’t been accessed in weeks. Are you certain you want to continue?”";
		ConversationActor = Actors.AI_Fridge();

		{
			var choiceA = NewEventChoice("LEAVE");
			choiceA.AddNextEvent<Fridge_A_2_Leave>();
		}
        
		{
			var choiceB = NewEventChoice("ACCESS FRIDGE DATA");
			choiceB.AddNextEvent<Fridge_A_2_Access>();
		}
    }
}

public class Fridge_A_2_Leave : EventBase
{
    public override void StartEvent()
    {
        Text = "Nervous. “I’m not that interesting anyway. I’ll just give you some more time to reconsider.”";
		ConversationActor = Actors.AI_Fridge();
		
        AddContinueChoice();
    }
}

public class Fridge_A_2_Access : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “You still want to access my data?”";
		ConversationActor = Actors.AI_Fridge();

		{
			var choiceA = NewEventChoice("AFFIRMATIVE");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired>();
		}
    }
}


public class Fridge_A_2_Access_Expired : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “Many products have an 'expired' status. Are you certain you want to continue?”";
		ConversationActor = Actors.AI_Fridge();

		{
			var choiceA = NewEventChoice("LEAVE");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Leave>();
		}

		{
			var choiceA = NewEventChoice("ACCESS FRIDGE DATA");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Final>();
		}
    }
}


public class Fridge_A_2_Access_Expired_Leave : EventBase
{
    public override void StartEvent()
    {
        Text = "“I'm just very professionally affected. Don't stay… Goodbye.”";
		ConversationActor = Actors.AI_Fridge();

		AddContinueChoice();
    }
}


public class Fridge_A_2_Access_Expired_Final : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “Do you really think I’m cool enough? Well… Thank you.”";
		ConversationActor = Actors.AI_Fridge();

		{
			var choiceA = NewEventChoice(">> FRIDGE DATA UNLOCKED ");
			choiceA.AddNextEvent<Fridge_B_1_Access_Menu>();

			choiceA.OnChoiceSelected += (Choice c) => {
				State.FridgeState = E_FridgeState.AccessUnlocked;
			};
		}
    }
}


