using UnityEngine;

public class Alinna_Congratulations_1 : Event
{
	public override void PlayEvent()
	{
		Text = "Look at you go. Quite the work you’ve done. You’ve deserved some rest. Go along now, back to your comfortable charging dock. Good work today.\nWe’ll take it easy tomorrow.\nMaybe clean the plants, just for a laugh.";
		EventActor = Actors.AI_Alinna();

		{
			var choice = NewChoice("[puzzled] affirmative.");
			choice.AddNextEvent<Alinna_Congratulations_2>();
		}
	}
}


public class Alinna_Congratulations_2 : Event
{
	public override void PlayEvent()
	{
		Text = "You have nothing to worry about. Your list is completed.\nCongratulations.\nGo, rest already. Don’t want to have a half-charged Taango moving about.";
		EventActor = Actors.AI_Alinna();

		{
			var choice = NewChoice("[glad] affirmative.");
		}
	}
}
