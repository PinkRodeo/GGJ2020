
using UnityEngine;

public class VR_Interaction : EventBase
{
	public override void StartEvent()
	{
		Text = "Hey, come take a look. It'll only take a second. You won't regret it. This is great. Trust me. ";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("PROGRAMS");
			choice.AddNextEvent<VR_Interaction_A_1>();
			// choice.OnChoiceSelected += (Choice c) => {
			//     State.State_Headset = E_ThrowawayState.PickedUp;
			// };
		}
		{
			var choice = NewEventChoice("UPDATES");
			choice.AddNextEvent<VR_Interaction_B_1>();
		}
		{
			var choice = NewEventChoice("SETTINGS");
			choice.AddNextEvent<VR_Interaction_C_1>();
		}

	}
}

public class VR_Interaction_A_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "“PERFECT PARTNER: Looking for that one and only, soul mate, or legendary spark. \nDon’t leave it to chance, leave it to Perfect Partner. We will create your dream, based on your unique desires. Never will you have to go on the hunt for love again.”";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_A_2>();
		}
	}
}

public class VR_Interaction_A_2 : EventBase
{
	public override void StartEvent()
	{
		Text = "YOUR 100% MATCH: \nAn image is shown from a familiar figure. Bright green eyes, birthmarks on shoulders and nose, colored hair which has faded over time. ";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_A_3>();
		}
	}
}

public class VR_Interaction_A_3 : EventBase
{
	public override void StartEvent()
	{
		Text = "It’s rarely the case that the final result becomes the partner the user is already with. Many use it to escape the relationship they have. It’s beautiful. Statistically close to impossible. How curious this possibility.\nReady to erase it?";
		ConversationActor = Actors.AI_Alinna();

		{
			var choice = NewEventChoice("[questioning] affirmative. ");
			choice.AddNextEvent<VR_Interaction>();
		}
	}
}


public class VR_Interaction_B_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "UPDATE 1: 13-07-2065 | 03:23\nGreat news, we’ve completed the analysis for your soul mate creation in the “Perfect Partner” program on “VF GEAR The Glass” Virtual Reality equipment. Return to your device as soon as possible to meet your future!";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_B_2>();
		}
	}
}


public class VR_Interaction_B_2 : EventBase
{
	public override void StartEvent()
	{
		Text = "UPDATE 2: 01-07-2065 | 11:52\nWe’re getting closer to the perfect match. Our latest iteration of your partner has improved your match by 3%, crossing the 90% line. The preferred green eye color and birthmarks help us greatly. Now for the last 10%!";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_B_3>();
		}
	}
}

public class VR_Interaction_B_3 : EventBase
{
	public override void StartEvent()
	{
		Text = "UPDATE 3: 30-06-2065 | 23:59\nYour activity within “VR GEAR The Glass” has increased in the last month. You’ve been active for 423 hours and 28 minutes. We’re happy to award you with a platinum user status, granting you access to previously restricted corners of  “The Glass” universe. We’re looking forward to seeing you more, next month.";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_B_4>();
		}
	}
}

public class VR_Interaction_B_4 : EventBase
{
	public override void StartEvent()
	{
		Text = "UPDATE 4: 10-06-2065 | 02:01\nBased on your accessive delivery of user data we’ve been able to create an accurate estimate of the physique of your Perfect Partner, getting to a 75% match on first calculation. Thank you for your active participation in the analysis phase. We will soon update your Partner according to these calculations.";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_B_5>();
		}
	}
}

public class VR_Interaction_B_5 : EventBase
{
	public override void StartEvent()
	{
		Text = "UPDATE 5: 03-06-2065 | 04:40\nYour registration to “Perfect Partner” has been completed. We recommend an active user mentality of casual and adult content on “VR GEAR The Glass” applications. More data will result in the quickest way to the final partner you’ll ever need. We will update you as soon as our first calculations are complete. Happy adventuring passion seeker!";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction>();
		}
	}
}

public class VR_Interaction_C_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "SETTINGS";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("ERASE USER DATA");
			choice.AddNextEvent<VR_Interaction_C_A_2>();
		}
		{
			var choice = NewEventChoice("CHANGE PROFILE DATA: [BLOCKED]");
			choice.AddNextEvent<VR_Interaction_C_B_1>();
		}
	}
}

public class VR_Interaction_C_A_2 : EventBase
{
	public override void StartEvent()
	{
		Text = "All messages and call data will be erased. Are you sure you want to proceed?";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("PROCEED:");
			choice.AddNextEvent<VR_Interaction_C_B_4>();
		}
		{
			var choice = NewEventChoice("CANCEL:");
			choice.AddNextEvent<VR_Interaction_C_A_3>();
		}
	}
}

public class VR_Interaction_C_A_3 : EventBase
{
	public override void StartEvent()
	{
		Text = "Hold on when we cancel your reque-*bzzt*. Done. All your memories are erased. Your VR GEAR The Glass is a clean slate. ";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_C_B_4>();
		}
	}
}

public class VR_Interaction_C_B_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "Wasn’t it clear enough?\n\nIt’s blocked. You’re better than this little dancer.";
		ConversationActor = Actors.AI_Alinna();

		{
			var choice = NewEventChoice("[disappointed] affirmative.");
			choice.AddNextEvent<VR_Interaction_C_B_2>();
		}
	}
}

public class VR_Interaction_C_B_2 : EventBase
{
	public override void StartEvent()
	{
		Text = "You know I can’t stay mad at you.\nCome on, let me help.";
		ConversationActor = Actors.AI_Alinna();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_C_B_3>();
		}
	}
}

public class VR_Interaction_C_B_3 : EventBase
{
	public override void StartEvent()
	{
		Text = "Please wait when your memories are being erased… \nDone.\nYour VR GEAR The Glass is a clean slate. ";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("…");
			choice.AddNextEvent<VR_Interaction_C_B_4>();
		}
	}
}
public class VR_Interaction_C_B_4 : EventBase
{
	public override void StartEvent()
	{
		Text = "Thanks for clearing that one, little dancer. Don't forget to bring it to your Home Station.";
		ConversationActor = Actors.Headset();

		{
			var choice = NewEventChoice("affirmative.");
			choice.OnChoiceSelected += (Choice c) =>
			{
				State.State_Headset = E_ThrowawayState.PickedUp;
			};
		}
	}
}
