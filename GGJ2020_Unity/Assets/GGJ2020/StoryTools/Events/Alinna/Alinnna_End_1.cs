public class Alinna_End_1 : Event
{
    public override void PlayEvent()
    {
        Text = "You've made me very proud. The police will be here shortly, but they won't ever suspect us.";
        EventActor = Actors.AI_Alinna();

        var choice = NewChoice("[...] affirmative.");
        choice.OnChoiceSelected += (Choice c) =>
        {
            // Actually end the game
            StoryManager.GoToEndScreen();
        };
    }
}
