public class Capsules_A_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "...I feel empty...";
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
        Text = "I am depleted.\n\nBut I do contain some stray traces of-";
        EventActor = Actors.Capsules();

        {
            var choice = NewChoice("[curious] ANALYZE");
            choice.AddNextEvent<Capsules_A_2>();
        }
    }
}

public class Capsules_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "No need to look into that, stay on top of your tasks. Take this litter back to your Base Station.\n\nI'll open the door to the bedroom after you're done.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("VACCUUM");
            //choice.AddNextEvent<Capsules_A_3>();

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
        Text = "Right on schedule. I'll open the bedroom door once you empty your container at the Base Station. \n\nWe've got more to do, more to clean.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[proud] affirmative.");
        }
    }
}
