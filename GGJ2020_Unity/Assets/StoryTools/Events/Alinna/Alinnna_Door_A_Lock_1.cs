using UnityEngine;

public class Alinna_Door_A_Lock_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "Alinna locks door A behind you, some silly excuse. Tensions rising.";
		ConversationActor = Actors.AI_Alinna();

		AddContinueChoice();
	}
}
