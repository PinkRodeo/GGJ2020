public class Alinna_Door_A_Unlock_1 : Event
{
    public override void PlayEvent()
    {
        Text = "I've opened the door for you. Hurry along now.";
        EventActor = Actors.AI_Alinna();

        NewAffirmativeChoice();
    }
}
