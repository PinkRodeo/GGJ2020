using UnityEngine;

public class Alinna_Door_A_Unlock_1 : EventBase
{
	public override void StartEvent()
	{
		Text = "Alinna: I've opened the door for you.";
		ConversationActor = Actors.AI_Alinna();

		AddAffirmativeChoice();
	}
}
