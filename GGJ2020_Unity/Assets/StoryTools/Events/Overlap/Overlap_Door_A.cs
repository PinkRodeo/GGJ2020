using UnityEngine;

public class Overlap_Door_A : EventBase
{
    public override void StartEvent()
    {
		ConversationActor = Actors.AI_Alinna();

		if (State.IntroState == E_IntroState.Psycho)
		{
			Text = "I'm Helping";

			State.DoorAState = E_DoorState.ShutHard;

			{
				var choice = NewEventChoice();
				choice.Text = "... ... ACKNOWLEDGED";
				choice.OnChoiceSelected += (Choice c) => {

				};
			}

		}
		else if (State.DoorAState == E_DoorState.Unlocked)
		{
			Text = "Dummy Text.";
			Story.CloseEvent();
			State.DoorAState = E_DoorState.Open;
		}
		else
		{
			Text = "Dummy Text.";
			Story.CloseEvent();
		}
    }
}
