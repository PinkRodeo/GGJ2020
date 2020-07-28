using UnityEngine;

public class Alinna_Door_A_Lock_1 : Event
{
	public override void PlayEvent()
	{
		Text = "Alinna locks door A behind you, some silly excuse. Tensions rising.";
		EventActor = Actors.AI_Alinna();

		AddContinueChoice();
	}
}
