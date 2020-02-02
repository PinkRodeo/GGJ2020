
public class TestEventA : EventBase
{
    public override void StartEvent()
    {
        Text = "You see a door.";
		ConversationActor = Actors.World();

        var choiceA = NewEventChoice();
        choiceA.Text = "Enter the other room.";
        choiceA.AddReward<StartEventReward<TestEventB>>();

        AddChoice(choiceA);

        var choiceB = NewEventChoice();
        choiceB.Text = "Look around the current room.";
        choiceB.AddReward<StartEventReward<TestEventC>>();
        AddChoice(choiceB);

        AddContinueChoice();

        //choiceB.Select();
    }
}
