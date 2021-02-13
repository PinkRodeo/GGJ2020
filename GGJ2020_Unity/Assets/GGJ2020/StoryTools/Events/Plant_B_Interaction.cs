using UnityEngine;

public class Plant_B_Interaction : Event
{
	public override void PlayEvent()
	{
		Text = "I absorb energy from the sun. What have you done today?";
		EventActor = Actors.AI_Plant_BLINI();

		AddContinueChoice();
	}
}
