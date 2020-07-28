using UnityEngine;

public class Overlap_Door_B : Event
{
	public override void PlayEvent()
	{
		EventActor = Actors.AI_Alinna();

		if (State.IntroState == E_IntroState.Psycho && State.Door_B_State != E_DoorState.ShutHard)
		{
			Text = "I can tell your battery is getting low. \n\nPlease proceed to your charging station.";

			State.Door_B_State = E_DoorState.ShutHard;

			{
				var choice = NewChoice("ACKNOWLEDGED");
				choice.OnChoiceSelected += (Choice c) =>
				{

				};
			}

		}
		else if (State.Door_B_State == E_DoorState.Unlocked)
		{
			Text = "Dummy Text.";
			StoryManager.CloseCurrentEvent();
			State.Door_B_State = E_DoorState.Open;
		}
		else
		{
			Text = "Dummy Text.";
			StoryManager.CloseCurrentEvent();
		}
	}
}
