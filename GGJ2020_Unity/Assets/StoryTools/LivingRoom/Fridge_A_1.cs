﻿using UnityEngine;
public class Fridge_A_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge Description";

        {
			var choiceA = NewEventChoice("ACCESS FRIDGE DATA");
			choiceA.AddNextEvent<Fridge_A_2>();
			AddChoice(choiceA);
		}
    }
}

public class Fridge_A_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "Access Denied. Fridge says: “My data hasn’t been accessed in weeks. Are you certain you want to continue?”";

		{
			var choiceA = NewEventChoice("LEAVE");
			choiceA.AddNextEvent<Fridge_A_2_Leave>();
			AddChoice(choiceA);
		}
        
		{
			var choiceB = NewEventChoice("ACCESS FRIDGE DATA");
			choiceB.AddNextEvent<Fridge_A_2_Access>();
			AddChoice(choiceB);
		}
    }
}

public class Fridge_A_2_Leave : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “I’m not that interesting anyway. I’ll just stay here.”";
		
        AddContinueChoice();
    }
}

public class Fridge_A_2_Access : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “You still want to access my data?”";

		{
			var choiceA = NewEventChoice("AFFIRMATIVE");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired>();
			AddChoice(choiceA);
		}
    }
}


public class Fridge_A_2_Access_Expired : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “Products have an 'expired' status. Are you certain you want to continue?”";

		{
			var choiceA = NewEventChoice("LEAVE");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Leave>();
			AddChoice(choiceA);
		}

		{
			var choiceA = NewEventChoice("ACCESS FRIDGE DATA");
			choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Final>();
			AddChoice(choiceA);
		}
    }
}


public class Fridge_A_2_Access_Expired_Leave : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “I guess I did take the advice too seriously. Stay… Goodbye.”";

		AddContinueChoice();
    }
}


public class Fridge_A_2_Access_Expired_Final : EventBase
{
    public override void StartEvent()
    {
        Text = "Fridge says: “Do you really think I’m still cool enough? Well… Thank you.”";

		{
			var choiceA = NewEventChoice(">> FRIDGE DATA UNLOCKED ");
			choiceA.AddNextEvent<Fridge_B_1_Access_Menu>();

			choiceA.OnChoiceSelected += (Choice c) => {
				State.FridgeState = E_FridgeState.AccessUnlocked;
			};
			AddChoice(choiceA);
		}
    }
}


