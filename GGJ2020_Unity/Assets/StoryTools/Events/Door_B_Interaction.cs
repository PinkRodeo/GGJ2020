
using UnityEngine;

public class Door_B_Interaction : EventBase
{
    public override void StartEvent()
    {
		ConversationActor = Actors.AI_Alinna();

		if (State.Door_B_State == E_DoorState.Locked)
		{
			Text = "First clean.";
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
			Story.CloseEvent();
        }
    }
}
