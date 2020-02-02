
using UnityEngine;

public class Plant_B_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "We don't need you!!";
        ConversationActor = Actors.AI_Plant();

        AddContinueChoice();
    }
}
