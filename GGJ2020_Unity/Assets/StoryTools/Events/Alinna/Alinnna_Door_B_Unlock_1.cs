using UnityEngine;

public class Alinna_Door_B_Unlock_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Only one room to go to.";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("[excited] affirmative.");
            choice.AddNextEvent<Alinna_Door_B_Unlock_2>();
        }
    }
}


public class Alinna_Door_B_Unlock_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "I like your energy, but there is still enough to do. You have an important task here. \nI’m trusting you. Quickly clear you container at the home station.\nThis last room will be a tricky one. But you might have what it takes. The door will be open when you get back.";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("[determined] affirmative.");
        }
    }
}

