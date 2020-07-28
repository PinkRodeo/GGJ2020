using UnityEngine;

public class Alinna_Door_B_Unlock_1 : Event
{
	public override void PlayEvent()
	{
		Text = "Only one room to go to.";
		EventActor = Actors.AI_Alinna();

		{
			var choice = NewChoice("[excited] affirmative.");
			choice.AddNextEvent<Alinna_Door_B_Unlock_2>();
		}
	}
}

public class Alinna_Door_B_Unlock_2 : Event
{
	public override void PlayEvent()
	{
		Text = "I like your energy, but there is still enough to do. You have an important task here. \nI’m trusting you. Quickly clear you container at the home station.\nThis last room will be a tricky one. But you might have what it takes. The door will be open when you get back.";
		EventActor = Actors.AI_Alinna();

		{
			var choice = NewChoice("[determined] affirmative.");
		}
	}
}

