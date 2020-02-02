using UnityEngine;

public class Alinna_End_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "You've made me very proud. The detective will be here shortly, but they won't ever suspect us.";
        ConversationActor = Actors.AI_Alinna();

        var choice = NewEventChoice("affirmative.");
        choice.OnChoiceSelected += (Choice c) =>
        {
            Story.GoToEndScreen();
        };
    }
}
