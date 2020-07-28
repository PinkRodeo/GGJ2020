
public class TestEventC : EventBase
{
	public override void StartEvent()
	{
		Text = "Not a lot of interesting stuff is happening in the room.";
		ConversationActor = Actors.World();

		AddContinueChoice();
	}
}
