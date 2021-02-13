
public class TestEventA : Event
{
	public override void PlayEvent()
	{
		Text = "You see a door.";
		EventActor = Actors.AI_Alinna();

		var choiceA = NewEventChoice();
		choiceA.Text = "Enter the other room.";
		choiceA.AddReward<StartEventReward<TestEventB>>();

		var choiceB = NewEventChoice();
		choiceB.Text = "Look around the current room.";
		choiceB.AddReward<StartEventReward<TestEventC>>();

		AddContinueChoice();

		//choiceB.Select();
	}
}
