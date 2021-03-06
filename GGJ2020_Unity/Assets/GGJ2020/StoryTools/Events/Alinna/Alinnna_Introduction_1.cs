public class Alinna_Introduction_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Good morning little one. Did you charge well?";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[sleepy] affirmative.");
            choice.AddNextEvent<Alinna_Introduction_2>();
        }
    }
}

public class Alinna_Introduction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Perfect. I have the chores for today. Nothing crazy.\n\nPlease clean the trash from the livingroom. I will get back to you once you’re done.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[excited] affirmative.");
        }
    }
}
