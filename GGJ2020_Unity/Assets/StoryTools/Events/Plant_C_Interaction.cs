
using UnityEngine;

public class Plant_C_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "We're the superior beings, we don't need maintence.";
        ConversationActor = Actors.AI_Plant();

        AddContinueChoice();
    }
}
