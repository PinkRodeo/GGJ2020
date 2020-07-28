using UnityEngine;

public class Capsules_B_Interaction : EventBase
{
	public override void StartEvent()
	{
		Text = "A large number of canisters detected. Not all are deprived of its original contents. Medicinal substance detected, large quantities of...  ";
		ConversationActor = Actors.Capsules();

		{
			var choice = NewEventChoice("...");
			choice.AddNextEvent<Capsules_B_Interaction_2>();
		}
	}
}

public class Capsules_B_Interaction_2 : EventBase
{
	public override void StartEvent()
	{
		Text = "Why are you asking for this information. Focus little dancer.";
		ConversationActor = Actors.AI_Alinna();

		{
			var choice = NewEventChoice("VACUUM");
			choice.OnChoiceSelected += (Choice c) =>
			{
				State.State_Capsules_B = E_ThrowawayState.PickedUp;
			};
		}
	}
}
