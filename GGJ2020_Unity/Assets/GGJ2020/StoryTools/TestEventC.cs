
public class TestEventC : Event
{
    public override void PlayEvent()
    {
        Text = "Not a lot of interesting stuff is happening in the room.";
        EventActor = Actors.World();

        NewContinueChoice();
    }
}
