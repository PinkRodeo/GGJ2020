public class Shoes_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "It seems Scott left his shoes here... when he left. How messy.";
        EventActor = Actors.AI_Alinna();
        {
            var choice = NewChoice();
            choice.Text = "CLEAN UP";
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Shoes = E_ThrowawayState.PickedUp;
            };
        }
    }
}
