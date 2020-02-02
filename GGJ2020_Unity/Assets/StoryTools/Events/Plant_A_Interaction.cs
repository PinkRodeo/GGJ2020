
using UnityEngine;

public class Plant_A_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "All life on Earth exists because of us. Stop distracting us. Do you want everything to die?";
        ConversationActor = Actors.AI_Plant_PLANTO();

        {
            var choice = NewEventChoice("[hurt] affirmative.");
            choice.AddNextEvent<Plant_A_Interaction_2>();
        }
    }
}

public class Plant_A_Interaction_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "Typical. Robots.";
        ConversationActor = Actors.AI_Plant_PLANTO();

        AddContinueChoice();
    }
}
