
using UnityEngine;

public class BaseStation_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "This is the basestation, where you live and the trash goes.";
        ConversationActor = Actors.AI_Alinna();
        Story.CloseEvent();

        if (State.State_Capsules_A == E_ThrowawayState.PickedUp)
        {
            Story.AddEvent<BaseStation_Dispose_Capsules_A_1>();
        }
        else if (State.State_Headset == E_ThrowawayState.PickedUp)
        {
            Story.AddEvent<BaseStation_Dispose_Headset_1>();
        }
        else if (State.State_Phone_A_Scott == E_ThrowawayState.PickedUp)
        {
            Story.AddEvent<BaseStation_Dispose_Phone_A_Scott_1>();
        }
        else if (State.State_Capsules_B == E_ThrowawayState.PickedUp)
        {
            Story.AddEvent<BaseStation_Dispose_Capsules_B_1>();
        }
        else if (State.State_Phone_B_Jen == E_ThrowawayState.PickedUp)
        {
            Story.AddEvent<BaseStation_Dispose_Phone_B_Jen_1>();
        }
        else if (State.State_Vape == E_ThrowawayState.PickedUp)
        {
            Story.AddEvent<BaseStation_Dispose_Vape_1>();
        }
        else if (State.IntroState == E_IntroState.Psycho)
        {
            Story.AddEvent<BaseStation_Dispose_Vacuum_1>();
        }
        else
        {
            Story.AddEvent<BaseStation_Go_Find_Trash>();
        }
    }
}


public class BaseStation_Dispose_Vacuum_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Thank you for your services";
        ConversationActor = Actors.AI_Alinna();

        Debug.Log("Ennd of game");

        AddContinueChoice();
    }
}

public class BaseStation_Go_Find_Trash : EventBase
{
    public override void StartEvent()
    {
        Text = "There is still dirt.";
        ConversationActor = Actors.AI_Alinna();

        NewEventChoice("AFFIRMATIVE");
    }
}

public class BaseStation_Dispose_Capsules_A_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Confirm the disposal of the Capsules_A";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("CONFIRM");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Capsules_A = E_ThrowawayState.ThrownInBaseStation;
            };
        }
    }
}
public class BaseStation_Dispose_Headset_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Confirm the disposal of the Headset";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("CONFIRM");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Headset = E_ThrowawayState.ThrownInBaseStation;
            };
        }
    }
}
public class BaseStation_Dispose_Phone_A_Scott_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Confirm the disposal of the Phone_A_Scott";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("CONFIRM");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Phone_A_Scott = E_ThrowawayState.ThrownInBaseStation;
            };
        }
    }
}
public class BaseStation_Dispose_Capsules_B_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Confirm the disposal of the Capsules_B";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("CONFIRM");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Capsules_B = E_ThrowawayState.ThrownInBaseStation;
            };
        }
    }
}
public class BaseStation_Dispose_Phone_B_Jen_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Confirm the disposal of the Phone_B_Jen";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("CONFIRM");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Phone_B_Jen = E_ThrowawayState.ThrownInBaseStation;
            };
        }
    }
}
public class BaseStation_Dispose_Vape_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Confirm the disposal of the Vape";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("CONFIRM");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Vape = E_ThrowawayState.ThrownInBaseStation;
            };
        }
    }
}