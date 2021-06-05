public class Plant_C_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "...a robot must protect its own existence as long as such protection does not conflict with the First or Second Laws...";
        EventActor = Actors.AI_Plant_JULES_FERN();

        {
            var choice = NewChoice("[curious] affirmative.");
            choice.AddNextEvent<Plant_C_Interaction_2>();
        }
    }
}

public class Plant_C_Interaction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "...So get lost, if you know what's good for you.";
        EventActor = Actors.AI_Plant_JULES_FERN();

        {
            var choice = NewChoice("[hurt] affirmative.");
        }
    }
}
