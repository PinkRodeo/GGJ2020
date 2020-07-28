using UnityEngine;

public class Alinna_Finish_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "Alinna thanks you for your hard work. The police show up. You get yeeted.";
		ConversationActor = Actors.AI_Alinna();

		AddContinueChoice();
	}
}
