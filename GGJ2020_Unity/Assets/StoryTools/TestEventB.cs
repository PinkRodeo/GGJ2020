
public class TestEventB : EventBase
{
	public override void StartEvent()
	{
		Text = "You're in the other room.";
		ConversationActor = Actors.Phone_Jen();

		var choiceA = NewEventChoice();
		choiceA.Text = "Go back to the first room.";
		choiceA.AddReward<StartEventReward<TestEventA>>();

		AddContinueChoice();
	}
}
