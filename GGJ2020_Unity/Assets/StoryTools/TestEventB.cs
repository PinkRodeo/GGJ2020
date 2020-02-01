
public class TestEventB : EventBase
{
    public override void StartEvent()
    {
        Text = "You're in the other room.";

        var choiceA = NewEventChoice();
        choiceA.Text = "Go back to the first room.";
        choiceA.AddReward<StartEventReward<TestEventA>>();

        AddChoice(choiceA);

        AddContinueChoice();
    }
}
