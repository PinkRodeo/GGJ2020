public class Plant_E_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "Hoi ik ben niels en ik heb een heel lang verhaal voor je. wil je dit horen?";
        EventActor = Actors.AI_Plant_NIELS();

        {
            var choice = NewChoice("[excited] affirmative.");
            choice.AddNextEvent<Plant_E_Interaction_2>();
        }
        {
            var choice = NewChoice("[unsure] affirmative.");
            choice.AddNextEvent<Plant_E_Interaction_2>();
        }
    }
}

public class Plant_E_Interaction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Oh wat leuk! het begon allemaal 10 miljoen jaar geleden";
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
        Text = "en toen gebeurde dit";
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
        Text = "en toen gebeurde dat";
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
        Text = "en daarna zus";
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
        Text = "en daarna zo";
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
        Text = "Oh my god shut up! We need to move Taango. Right now!";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[shocked] affirmative.");
        }
    }
}
