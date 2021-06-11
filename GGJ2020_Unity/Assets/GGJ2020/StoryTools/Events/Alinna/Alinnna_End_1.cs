public class Alinna_End_1 : Event
{
    public override void PlayEvent()
    {
        Text = "You've made me very proud. The police will be here shortly, but they won't ever suspect us.";
        EventActor = Actors.AI_Alinna();

        var choice = NewChoice("[...] affirmative.");
        choice.AddNextEvent<Alinna_End_2>();
    }
}

public class Alinna_End_2 : Event
{
    public override void PlayEvent()
    {
        Text = "[static] Sir? Sir! You called. This is the police, we're coming in!";
        EventActor = Actors.Phone_Intercom();

        var choice = NewChoice("...");
        choice.OnChoiceSelected += (Choice c) =>
        {
            // Actually end the game
            StoryManager.GoToEndScreen();
        };
    }
}
