
using UnityEngine;

public class Vape_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "Make it squeeky clean, little dancer.";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice();
            choice.Text = "CLEAN UP";
            choice.OnChoiceSelected += (Choice c) => {
                State.State_Vape = E_ThrowawayState.PickedUp;
            };
        }
    }
}
