public class Plant_A_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "All life on Earth exists because of us. Stop distracting us. Do you want everything to die?";
        EventActor = Actors.AI_Plant_PLANTO();

        {
            var choice = NewChoice("[hurt] affirmative.");
            choice.AddNextEvent<Plant_A_Interaction_2>();
        }
    }
}

public class Plant_A_Interaction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Typical. Robots.";
        EventActor = Actors.AI_Plant_PLANTO();

        NewContinueChoice();
    }
}
