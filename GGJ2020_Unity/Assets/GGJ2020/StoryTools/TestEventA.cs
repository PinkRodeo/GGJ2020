
public class TestEventA : Event
{
    public override void PlayEvent()
    {
        Text = "You see a door.";
        EventActor = Actors.AI_Alinna();

        var choiceA = NewChoice();
        choiceA.Text = "Enter the other room.";
        choiceA.AddReward<StartEventReward<TestEventB>>();

        var choiceB = NewChoice();
        choiceB.Text = "Look around the current room.";
        choiceB.AddReward<StartEventReward<TestEventC>>();

        NewContinueChoice();

        //choiceB.Select();
    }
}
