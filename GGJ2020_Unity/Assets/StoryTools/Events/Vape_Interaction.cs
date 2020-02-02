
using UnityEngine;

public class Vape_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "Vape Interaction";
        ConversationActor = Actors.World();

        AddContinueChoice();

        // Text = "Dummy";
		// ConversationActor = Actors.AI_Fridge();

        // switch (State.FridgeState)
        // {   
        //     case E_FridgeState.FirstInteract:
        //         Story.AddEvent<Fridge_A_1>();
        //         break;
        //     case E_FridgeState.AccessUnlocked:
        //         Story.AddEvent<Fridge_B_1_Access_Menu>();
        //         break;
        //     default:
        //         Debug.Log("Didn't Implement: " + State.FridgeState.ToString());
        //         break;
        // }

        // Story.CloseEvent();
    }
}
