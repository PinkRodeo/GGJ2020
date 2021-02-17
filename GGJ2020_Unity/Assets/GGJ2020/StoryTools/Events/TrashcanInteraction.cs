using UnityEngine;

public class TrashcanInteraction : Event
{
    public override void PlayEvent()
    {
        Text = "Dummy";
        EventActor = Actors.AI_Trashcan();
        StoryManager.CloseCurrentEvent();

        switch (State.TrashcanState)
        {
            case E_TrashcanState.FirstInteract:
                StoryManager.AddNextEvent<Trashcan_A_1>();
                break;
            case E_TrashcanState.AccessUnlocked:
                StoryManager.AddNextEvent<Trashcan_B_1_Inventory>();
                break;
            default:
                Debug.Log("Didn't Implement: " + State.TrashcanState.ToString());
                break;
        }
    }
}
