public class Alinna_Door_B_Lock_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Alinna locks door B behind you, some silly excuse.";
        EventActor = Actors.AI_Alinna();

        NewContinueChoice();
    }
}
