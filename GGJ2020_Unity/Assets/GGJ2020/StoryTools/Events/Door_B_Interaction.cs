public class Door_B_Interaction : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.AI_Alinna();

        if (State.Door_B_State == E_DoorState.Locked)
        {
            Text = "I don't think you're ready for that one just yet. Stay focused.";
            NewContinueChoice();
        }
        else if (State.Door_B_State == E_DoorState.ShutHard)
        {
            Text = "Just hurry.";
            NewContinueChoice();
        }
        else
        {
            Text = "Dummy";
            StoryManager.CloseCurrentEvent();
        }
    }
}
