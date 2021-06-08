public class AlinnaOS_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "placeholder text";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<AlinnaOS_Interaction_2>();
        }
    }
}

public class AlinnaOS_Interaction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "placeholder text";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[hurt] affirmative.");
        }
    }
}
