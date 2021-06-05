public class Alinna_Door_B_Unlock_1 : Event
{
    public override void PlayEvent()
    {
        Text = "I like your energy, but there is still enough to do. You have an important task here. \n\nI’m trusting you.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[excited] affirmative.");
            choice.AddNextEvent<Alinna_Door_B_Unlock_2>();
        }
    }
}

public class Alinna_Door_B_Unlock_2 : Event
{
    public override void PlayEvent()
    {
        Text = "The bathroom door is open, go along now. \n\nDon't mind the knocking on the door.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[determined] affirmative.");
        }
    }
}
