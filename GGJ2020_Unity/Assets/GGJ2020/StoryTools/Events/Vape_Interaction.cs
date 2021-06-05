public class Vape_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "The electronic cigarette, ordered by Jennette, has been used last on the 1st of July. High levels of C17H3ClN4, also known as...";
        EventActor = Actors.Vape();

        {
            var choice = NewChoice("[curious] ANALYZE.");
            choice.AddNextEvent<Vape_Interaction_2>();
        }
    }
}

public class Vape_Interaction_2 : Event
{
    public override void PlayEvent()
    {
      Text = "Lots to do and so little time! Don’t bother with reading into it too much.";
      EventActor = Actors.AI_Alinna();
      {
          var choice = NewChoice();
          choice.Text = "VACCUUM";
          choice.OnChoiceSelected += (Choice c) =>
          {
              State.State_Vape = E_ThrowawayState.PickedUp;
          };
      }
    }
}
