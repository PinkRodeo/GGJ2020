
public class TestEventB : Event
{
    public override void PlayEvent()
    {
        Text = "You're in the other room.";
        EventActor = Actors.Phone_Jen();

        var choiceA = NewChoice();
        choiceA.Text = "Go back to the first room.";
        choiceA.AddReward<StartEventReward<TestEventA>>();

        NewContinueChoice();
    }
}
