public class Capsules_A_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "I feel empty....";
        EventActor = Actors.Capsules();

        {
            var choice = NewChoice("ANALYZE");
            choice.AddNextEvent<Capsules_A_1>();
        }
    }
}

public class Capsules_A_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Capsules are depleted.\n\nThey do contain an unknown stray traces...";
        EventActor = Actors.Capsules();

        {
            var choice = NewChoice("ANALYZE");
            choice.AddNextEvent<Capsules_A_2>();
        }
    }
}

public class Capsules_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "No need to look into that, stay on top of your tasks. Take this litter out.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("VACUUM");
            choice.AddNextEvent<Capsules_A_3>();

            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Capsules_A = E_ThrowawayState.PickedUp;
            };
        }
    }
}

public class Capsules_A_3 : Event
{
    public override void PlayEvent()
    {
        Text = "Right on schedule. Please empty your container at your perfect little home station, we have more to do, more to clean.\nI will open the door to the bedroom for you after you’re done. ";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[proud] affirmative. ");
        }
    }
}