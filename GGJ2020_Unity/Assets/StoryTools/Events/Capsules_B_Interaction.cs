
using UnityEngine;

public class Capsules_B_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "Vape Capsules in the bathroom Interaction";
        ConversationActor = Actors.World();

        {
            var choice = NewEventChoice();
            choice.Text = "CLEAN UP CAPSULES";
            choice.OnChoiceSelected += (Choice c) => {
                State.State_Capsules_B = E_ThrowawayState.PickedUp;
            };
        }
    }
}
