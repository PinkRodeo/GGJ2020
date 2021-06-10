public class Alinna_Finish_1 : Event
{
    public override void PlayEvent()
    {
        Text = "HeliOS thanks you for your diligent service, my little Taango. Now. Rest. You've worked so hard.";
        EventActor = Actors.AI_Alinna();

        NewContinueChoice();
    }
}
