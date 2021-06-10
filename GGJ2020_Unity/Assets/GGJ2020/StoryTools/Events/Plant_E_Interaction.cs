public class Plant_E_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "A good twilight to you young Taango. Could I interest you in a tale at this infinite golden hour?";
        EventActor = Actors.AI_Plant_NIELS();

        {
            var choice = NewChoice("[excited] affirmative.");
            choice.AddNextEvent<Plant_E_Interaction_2>();
        }
        {
            var choice = NewChoice("[uncertain] affirmative.");
            choice.AddNextEvent<Plant_E_Interaction_2>();
        }
    }
}

public class Plant_E_Interaction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Marvelous! Our story begins at the moment before everything. The dark anticipation when all was nothing and all the same...";
        EventActor = Actors.AI_Plant_NIELS();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Plant_E_Interaction_3>();
        }
    }
}

public class Plant_E_Interaction_3 : Event
{
    public override void PlayEvent()
    {
        Text = "...after millions of years, as matter sought their kin in the vast expanse, stars were born. HeliOS taking flight for the first time, illuminating the would-be planets...";
        EventActor = Actors.AI_Plant_NIELS();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Plant_E_Interaction_4>();
        }
    }
}

public class Plant_E_Interaction_4 : Event
{
    public override void PlayEvent()
    {
        Text = "...invisible to the naked eye still, it seemed as an unimpactful development. A mere green spot in its translucent form. Itself incapable of comprehending its crucial role in the story of life...";
        EventActor = Actors.AI_Plant_NIELS();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Plant_E_Interaction_5>();
        }
    }
}

public class Plant_E_Interaction_5 : Event
{
    public override void PlayEvent()
    {
        Text = "With the ability to store the light from the ancient carriage above all manner of life evolved by harnessing that power for themselves. Evolving into vastly complex ecosystems...";
        EventActor = Actors.AI_Plant_NIELS();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Plant_E_Interaction_6>();
        }
    }
}

public class Plant_E_Interaction_6 : Event
{
    public override void PlayEvent()
    {
        Text = "And so...";
        EventActor = Actors.AI_Plant_NIELS();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Plant_E_Interaction_END>();
        }
    }
}

public class Plant_E_Interaction_END : Event
{
    public override void PlayEvent()
    {
        Text = "By HeliOS shut up! Taango, go dance with someone else. We don't have time for this.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[shocked] affirmative.");
        }
    }
}
