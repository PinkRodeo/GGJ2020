using UnityEngine;

public class Capsules_B_Interaction : Event
{
	public override void PlayEvent()
	{
		Text = "A large number of canisters detected. Not all are deprived of its original contents. Medicinal substance detected, large quantities of...  ";
		EventActor = Actors.Capsules();

		{
			var choice = NewChoice("...");
			choice.AddNextEvent<Capsules_B_Interaction_2>();
		}
	}
}

public class Capsules_B_Interaction_2 : Event
{
	public override void PlayEvent()
	{
		Text = "Why are you asking for this information. Focus little dancer.";
		EventActor = Actors.AI_Alinna();

		{
			var choice = NewChoice("VACUUM");
			choice.OnChoiceSelected += (Choice c) =>
			{
				State.State_Capsules_B = E_ThrowawayState.PickedUp;
			};
		}
	}
}
