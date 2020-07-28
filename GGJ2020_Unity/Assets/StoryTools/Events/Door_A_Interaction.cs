using UnityEngine;

public class Door_A_Interaction : Event
{
	public override void PlayEvent()
	{
		EventActor = Actors.AI_Alinna();

		if (State.Door_A_State == E_DoorState.Locked)
		{
			Text = "I don’t think you’re done yet.";
			NewChoice("[sad] affirmative.");
		}
		else if (State.Door_A_State == E_DoorState.ShutHard)
		{
			Text = "Just hurry.";
			AddContinueChoice();
		}
		else
		{
			Text = "Dummy";
			StoryManager.CloseCurrentEvent();
		}
	}
}
