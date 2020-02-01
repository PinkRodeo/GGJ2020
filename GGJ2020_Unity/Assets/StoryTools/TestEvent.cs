
public class TestEvent : EventBase
{
    public override void StartEvent()
    {
        Text = "Hallo daar";

        var choiceA = NewEventChoice();
        choiceA.Text = "Choose A";
        AddChoice(choiceA);

        var choiceB = NewEventChoice();
        choiceB.Text = "Choose B";
        choiceB.AddReward<StartEventReward<TestEventB>>();
        AddChoice(choiceB);

        AddContinueChoice();

        //choiceB.Select();
    }
}
