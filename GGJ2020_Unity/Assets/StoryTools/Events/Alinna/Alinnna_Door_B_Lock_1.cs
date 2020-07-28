using UnityEngine;

public class Alinna_Door_B_Lock_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "Alinna locks door B behind you, some silly excuse.";
		ConversationActor = Actors.AI_Alinna();

		AddContinueChoice();
	}
}
