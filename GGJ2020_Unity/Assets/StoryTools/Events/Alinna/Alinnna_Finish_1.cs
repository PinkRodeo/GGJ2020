using UnityEngine;

public class Alinna_Finish_1 : Event
{
	public override void PlayEvent()
	{
		Text = "Alinna thanks you for your hard work. The police show up. You get yeeted.";
		EventActor = Actors.AI_Alinna();

		AddContinueChoice();
	}
}
