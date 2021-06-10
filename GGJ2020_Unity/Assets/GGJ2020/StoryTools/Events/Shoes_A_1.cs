public class Shoes_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "Scott was here just a few steps ago! He can't have gone far.";
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
      Text = "No point in wondering where he went. Move along now, back to your Base Station little dancer.";
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
