
using UnityEngine;

public class Capsules_A_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "I feel empty....";
        ConversationActor = Actors.Capsules();

        {
            var choice = NewEventChoice("ANALYZE");
            choice.AddNextEvent<Capsules_A_1>();
        }


    }
}

public class Capsules_A_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Capsules are deprived of any content.\n\nThey do contain an unknown stray substance...";
        ConversationActor = Actors.Capsules();

        {
            var choice = NewEventChoice("ANALYZE");
            choice.AddNextEvent<Capsules_A_2>();
        }
    }
}

public class Capsules_A_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "No need to look into that, just move on to your task.";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("VACUUM");
            choice.AddNextEvent<Capsules_A_3>();
            
            choice.OnChoiceSelected += (Choice c) => {
                State.State_Capsules_A = E_ThrowawayState.PickedUp;
            };
        }
    }
}

public class Capsules_A_3 : EventBase
{
    public override void StartEvent()
    {
        Text = "Right on schedule. Please empty your container at your perfect little home station, we have more to do, more to clean.\nI will open the door to the bedroom for you after you’re done. ";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("[proud] affirmative. ");
        }
    }
}