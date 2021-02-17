public class Vape_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "Make it squeeky clean, little dancer.";
        EventActor = Actors.AI_Alinna();
        {
            var choice = NewChoice();
            choice.Text = "CLEAN UP";
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Vape = E_ThrowawayState.PickedUp;
            };
        }
    }
}
