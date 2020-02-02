
using UnityEngine;

public class Vape_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "Vape Interaction";
        ConversationActor = Actors.World();

        {
            var choice = NewEventChoice();
            choice.Text = "CLEAN UP Vape";
            choice.OnChoiceSelected += (Choice c) => {
                State.State_Vape = E_ThrowawayState.PickedUp;
            };
        }
    }
}
