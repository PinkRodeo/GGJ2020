using UnityEngine;

public class Alinna_Congratulations_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "Look at you go. Quite the work you’ve done. You’ve deserved some rest. Go along now, back to your comfortable charging dock. Good work today.\nWe’ll take it easy tomorrow.\nMaybe clean the plants, just for a laugh.";
		ConversationActor = Actors.AI_Alinna();

		{
			var choice = NewEventChoice("[puzzled] affirmative.");
			choice.AddNextEvent<Alinna_Congratulations_2>();
		}
	}
}


public class Alinna_Congratulations_2 : EventBase
{
	public override void StartEvent()
	{
		Text = "You have nothing to worry about. Your list is completed.\nCongratulations.\nGo, rest already. Don’t want to have a half-charged Taango moving about.";
		ConversationActor = Actors.AI_Alinna();

		{
			var choice = NewEventChoice("[glad] affirmative.");
		}
	}
}
