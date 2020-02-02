using UnityEngine;

public class Overlap_Door_B : EventBase
{
    public override void StartEvent()
    {
		ConversationActor = Actors.AI_Alinna();

		if (State.IntroState == E_IntroState.Psycho && State.Door_B_State != E_DoorState.ShutHard)
		{
			Text = "I'm Helping";

			State.Door_B_State = E_DoorState.ShutHard;

			{
				var choice = NewEventChoice();
				choice.Text = "ACKNOWLEDGED";
				choice.OnChoiceSelected += (Choice c) => {

				};
			}

		}
		else if (State.Door_B_State == E_DoorState.Unlocked)
		{
			Text = "Dummy Text.";
			Story.CloseEvent();
			State.Door_B_State = E_DoorState.Open;
		}
		else
		{
			Text = "Dummy Text.";
			Story.CloseEvent();
		}
    }
}
