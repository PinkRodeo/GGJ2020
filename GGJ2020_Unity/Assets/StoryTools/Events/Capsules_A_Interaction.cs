
using UnityEngine;

public class Capsules_A_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "Vape Capsules are littered aroud.";
        ConversationActor = Actors.World();

        {
            var choice = NewEventChoice();
            choice.Text = "CLEAN UP CAPSULES";
            choice.OnChoiceSelected += (Choice c) => {
                State.DoorAState = E_DoorState.Open;
            };
        }
    }
}
