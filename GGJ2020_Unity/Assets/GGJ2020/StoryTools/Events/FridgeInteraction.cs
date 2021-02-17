using UnityEngine;

public class FridgeInteraction : Event
{
    public override void PlayEvent()
    {
        Text = "Dummy";
        EventActor = Actors.AI_Fridge();
        StoryManager.CloseCurrentEvent();

        switch (State.FridgeState)
        {
            case E_FridgeState.FirstInteract:
                StoryManager.AddNextEvent<Fridge_A_1>();
                break;
            case E_FridgeState.AccessUnlocked:
                StoryManager.AddNextEvent<Fridge_B_1_Access_Menu>();
                break;
            default:
                Debug.Log("Didn't Implement: " + State.FridgeState.ToString());
                break;
        }
    }
}
