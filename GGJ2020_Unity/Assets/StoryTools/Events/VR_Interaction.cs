
using UnityEngine;

public class VR_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "VR Goggles Interaction";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("WIPE DOWN HEADSET");
            choice.OnChoiceSelected += (Choice c) => {
                State.DoorBState = E_DoorState.Open;
            };
        }

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
