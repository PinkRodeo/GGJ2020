public class Alinna_Door_A_Unlock_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Alinna: I've opened the door for you.";
        EventActor = Actors.AI_Alinna();

        NewAffirmativeChoice();
    }
}
