using UnityEngine;

public class Alinna_Introduction_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Good morning little one. Did you charge fully?";
        ConversationActor = Actors.AI_Alinna();

		{
            var choice = NewEventChoice();
            choice.Text = "affirmative.";
            choice.AddNextEvent<Alinna_Introduction_2>();
        }
    }
}


public class Alinna_Introduction_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "Perfect. I have the chores for today. Just some simple ones.\nNothing crazy.\nPlease vacuum the livingroom. I will get back to you once you’re done.";
        ConversationActor = Actors.AI_Alinna();

		{
            var choice = NewEventChoice();
            choice.Text = "[excited] affirmative.";
        }
    }
}
