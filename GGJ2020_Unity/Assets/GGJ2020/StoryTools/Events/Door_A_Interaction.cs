using UnityEngine;

// Define a new type of event, "Door_A_Interaction"
public class Door_A_Interaction : Event
{

	// What happens when this event is played
	public override void PlayEvent()
	{
		// The UI skin (and ~portrait~) of this event is set to that of Alinna.
		// Check out Assets/StoryTools/Core/Actors.cs for a list of all available actors
		EventActor = Actors.AI_Alinna();

		// Normally you could just add some choices and be done with it, this door is special though
		// It first checks what the state of the story is, then changes what the event reads and what choices to display

		// Ask the "State" (where all StoryState is being stored) if Door_A is currently locked (by default it is)
		if (State.Door_A_State == E_DoorState.Locked)
		{
			// If it's locked, the event text becomes:
			Text = "I don’t think you’re done yet.";

			// And add a single choice button to this event, it does nothing it just reads this text
			NewChoice("[sad] affirmative.");
		}
		// Is the door ShutHard (happens at the end of the game where doors close after you go through them)
		else if (State.Door_A_State == E_DoorState.ShutHard)
		{
			// Change the text
			Text = "Just hurry.";
			// Adds a preset Choice text
			AddContinueChoice();
		}
		else
		{
			// Should no longer be interactable
			Text = "...";
			StoryManager.CloseCurrentEvent();
		}
	}
}
