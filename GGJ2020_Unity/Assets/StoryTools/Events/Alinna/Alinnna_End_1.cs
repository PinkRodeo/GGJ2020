using UnityEngine;

public class Alinna_End_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "THIS IS THE SOUND OF THE POLICE!";
        ConversationActor = Actors.AI_Alinna();

        AddContinueChoice();
    }
}
