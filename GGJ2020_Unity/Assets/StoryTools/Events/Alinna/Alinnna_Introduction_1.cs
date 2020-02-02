using UnityEngine;

public class Alinna_Introduction_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Alinna tells you about your tasklist.";
        ConversationActor = Actors.AI_Alinna();

		{
            var choice = NewEventChoice();
            choice.Text = "YES";
            choice.AddNextEvent<Alinna_Introduction_2>();
        }
    }
}


public class Alinna_Introduction_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "[Use WASD to control the PanC4ke Vacuum]";
        ConversationActor = Actors.AI_Alinna();

		AddContinueChoice();
    }
}
