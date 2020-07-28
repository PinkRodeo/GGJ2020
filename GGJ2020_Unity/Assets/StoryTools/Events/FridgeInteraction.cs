using UnityEngine;

public class FridgeInteraction : EventBase
{
	public override void StartEvent()
	{
		Text = "Dummy";
		ConversationActor = Actors.AI_Fridge();
		Story.CloseEvent();

		switch (State.FridgeState)
		{
			case E_FridgeState.FirstInteract:
				Story.AddEvent<Fridge_A_1>();
				break;
			case E_FridgeState.AccessUnlocked:
				Story.AddEvent<Fridge_B_1_Access_Menu>();
				break;
			default:
				Debug.Log("Didn't Implement: " + State.FridgeState.ToString());
				break;
		}
	}
}
