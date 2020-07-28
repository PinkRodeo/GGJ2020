
public class TestEventA : EventBase
{
	public override void StartEvent()
	{
		Text = "You see a door.";
		ConversationActor = Actors.AI_Alinna();

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
