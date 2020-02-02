
using UnityEngine;

public class Phone_Scott_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "Phone Scott Interaction";
        ConversationActor = Actors.Phone_Scott();

        {
            var choice = NewEventChoice();
            choice.Text = "CLEAN UP Phone";
            choice.OnChoiceSelected += (Choice c) => {
                State.State_Phone_A_Scott = E_ThrowawayState.PickedUp;
            };
        }
    }
}
