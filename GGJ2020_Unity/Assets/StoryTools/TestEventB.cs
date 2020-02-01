
public class TestEventB : EventBase
{
    public override void StartEvent()
    {
        Text = "Ghallo Event B";

        AddContinueChoice();
    }
}
