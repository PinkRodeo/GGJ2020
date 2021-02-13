using UnityEngine;

public class Door_B_Interaction : Event
{
	public override void PlayEvent()
	{
		EventActor = Actors.AI_Alinna();

		if (State.Door_B_State == E_DoorState.Locked)
		{
			Text = "Access Denied.\nYou’re not ready for the task that follows. Return later! ";
			AddContinueChoice();
		}
		else if (State.Door_B_State == E_DoorState.ShutHard)
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