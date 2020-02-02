
using UnityEngine;

public class Plant_C_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "...a robot must protect its own existence as long as such protection does not conflict with the First or Second Laws...";
        ConversationActor = Actors.AI_Plant_JULES_FERN();

        {
            var choice = NewEventChoice("[curious] affirmative.");
            choice.AddNextEvent<Plant_C_Interaction_2>();
        }
    }
}


public class Plant_C_Interaction_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "So get lost, if you know what's good for you.";
        ConversationActor = Actors.AI_Plant_JULES_FERN();

        {
            var choice = NewEventChoice("[hurt] affirmative.");
        }
    }
}
