public class Shoes_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "Scott was here just a few minutes ago! He can't have gone far.";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("[curious] affirmative.");
            choice.AddNextEvent<Shoes_Interaction_2>();
        }
    }
}

public class Shoes_Interaction_2 : Event
{
    public override void PlayEvent()
    {
      Text = "No point in wondering where he went. Humans always leave a mess.";
      EventActor = Actors.AI_Alinna();
      {
          var choice = NewChoice();
          choice.Text = "VACCUUM";
          choice.OnChoiceSelected += (Choice c) =>
          {
              State.State_Shoes = E_ThrowawayState.PickedUp;
          };
      }
    }
}
