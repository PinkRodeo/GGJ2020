public class Plant_D_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "Did you hear the story about the flower who went on a date with another flower?";
        EventActor = Actors.AI_Plant_EDDIE_LEAFLY();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Plant_D_Interaction_2>();
        }
    }
}

public class Plant_D_Interaction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Me neither. Now scram, lowlife.";
        EventActor = Actors.AI_Plant_EDDIE_LEAFLY();

        {
            var choice = NewChoice("[hurt] affirmative.");
            choice.AddNextEvent<Plant_D_Interaction_3>();
        }
    }
}

public class Plant_D_Interaction_3 : Event
{
    public override void PlayEvent()
    {
        Text = "I've never liked plants myself. Silicon and concrete are the future.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("affirmative.");
        }
    }
}
