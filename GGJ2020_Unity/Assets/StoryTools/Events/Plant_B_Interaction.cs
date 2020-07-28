using UnityEngine;

public class Plant_B_Interaction : EventBase
{
	public override void StartEvent()
	{
		Text = "I absorb energy from the sun. What have you done today?";
		ConversationActor = Actors.AI_Plant_BLINI();

		AddContinueChoice();
	}
}
