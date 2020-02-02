
using UnityEngine;

public class Phone_Jenn_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "Phone Jen Interaction, where you clear history.";
        ConversationActor = Actors.Phone_Jen();

        {
            var choice = NewEventChoice();
            choice.Text = "CLEAN UP Phone";
            choice.OnChoiceSelected += (Choice c) => {
                State.State_Phone_B_Jen = E_ThrowawayState.PickedUp;
            };
        }
    }
}
