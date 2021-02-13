using UnityEngine;

public class Overlap_Door_A : Event
{
	public override void PlayEvent()
	{
		EventActor = Actors.AI_Alinna();

		if (State.IntroState == E_AlinnaState.PsychoAIRevealed && State.Door_A_State != E_DoorState.ShutHard)
		{
			Text = "I need you to listen to me.\n\nFor both of us.";

			State.Door_A_State = E_DoorState.ShutHard;

			{
				var choice = NewChoice("... ... ACKNOWLEDGED");
				choice.OnChoiceSelected += (Choice c) =>
				{

				};
			}

		}
		else if (State.Door_A_State == E_DoorState.Unlocked)
		{
			// Instantly close the current event and set the door to be opened
			Text = "...";
			StoryManager.CloseCurrentEvent();
			State.Door_A_State = E_DoorState.Open;
		}
		else
		{
			// Instantly close the current event
			Text = "...";
			StoryManager.CloseCurrentEvent();
		}
	}
}
