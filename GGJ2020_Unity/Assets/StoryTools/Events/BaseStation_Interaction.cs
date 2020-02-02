
using UnityEngine;

public class BaseStation_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "This is your Home Station, where the trash goes and you live.";
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
            switch (State.CleanupState)
            {
                case E_CleanupState.LivingRoom:
                    Story.AddEvent<BaseStation_Go_Find_Trash_Livingroom>();
                    break;
                case E_CleanupState.Bedroom:
                    Story.AddEvent<BaseStation_Go_Find_Trash_Bedroom>();
                    break;
                case E_CleanupState.Bathroom:
                    Story.AddEvent<BaseStation_Go_Find_Trash_Bathroom>();
                    break;
                case E_CleanupState.Done:
                    Debug.LogError("This should not be encountered.");
                    break;
                default:
                    break;

            }

        }
    }
}

public class BaseStation_Interaction_Return : EventBase
{
    public override void StartEvent()
    {
        Text = "This is your Home Station, where the trash goes and you live.";
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
    }
}

public class BaseStation_Dispose_Vacuum_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Thank you for your services";
        ConversationActor = Actors.AI_Alinna();

        AddContinueChoice();
    }
}

public class BaseStation_Go_Find_Trash_Livingroom : EventBase
{
    public override void StartEvent()
    {
        Text = "You just woke up. Come on little dancer, we have work to do.";
        ConversationActor = Actors.AI_Alinna();

        NewEventChoice("[sleepy] affirmative.");
    }
}

public class BaseStation_Go_Find_Trash_Bedroom : EventBase
{
    public override void StartEvent()
    {
        Text = "You still have work to do. Chop chop. ";
        ConversationActor = Actors.AI_Alinna();

        NewEventChoice("[diligent] affirmative.");
    }
}

public class BaseStation_Go_Find_Trash_Bathroom : EventBase
{
    public override void StartEvent()
    {
        Text = "By heliOS, hurry!";
        ConversationActor = Actors.AI_Alinna();

        NewEventChoice("[hurried] affirmative.");
    }
}

public class BaseStation_Dispose_Capsules_A_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Welcome home.";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("EMPTY CONTAINER");
            choice.AddNextEvent<BaseStation_Dispose_Capsules_A_2>();
        }
    }
}

public class BaseStation_Dispose_Capsules_A_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "Capsules go *shoop*";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Capsules_A = E_ThrowawayState.ThrownInHomeStation;
                Story.AddEvent<BaseStation_Interaction_Return>();
            };
        }
    }
}
public class BaseStation_Dispose_Headset_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Welcome home.";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("EMPTY CONTAINER");
            choice.AddNextEvent<BaseStation_Dispose_Headset_2>();
        }
    }
}
public class BaseStation_Dispose_Headset_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "VR Headset goes *shoop*";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Headset = E_ThrowawayState.ThrownInHomeStation;

                if (State.State_Phone_A_Scott == E_ThrowawayState.OnFloor)
                {
                    Story.AddEvent<BaseStation_Dispose_Bedroom_Half_1>();
                }
                else
                {
                    Story.AddEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}

public class BaseStation_Dispose_Phone_A_Scott_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Welcome home.";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("EMPTY CONTAINER");
            choice.AddNextEvent<BaseStation_Dispose_Phone_A_Scott_2>();
        }
    }
}
public class BaseStation_Dispose_Phone_A_Scott_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "Scott's phone goes *shoop*";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Phone_A_Scott = E_ThrowawayState.ThrownInHomeStation;

                if (State.State_Headset == E_ThrowawayState.OnFloor)
                {
                    Story.AddEvent<BaseStation_Dispose_Bedroom_Half_1>();
                }
                else
                {
                    Story.AddEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}


public class BaseStation_Dispose_Bedroom_Half_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Just one more thing to clear from the bedroom! You're almost there.";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("[determined] affirmative.");
        }
    }
}

public class BaseStation_Dispose_Capsules_B_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Welcome home.";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("EMPTY CONTAINER");
            choice.OnChoiceSelected += (Choice c) =>
            {
                Story.AddEvent<BaseStation_Dispose_Capsules_B_2>();
            };
        }
    }
}

public class BaseStation_Dispose_Capsules_B_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "The capsules go *shoop*";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Capsules_B = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Phone_B_Jen;
                var item_state_b = State.State_Vape;

                if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    Story.AddEvent<BaseStation_Interaction_Return>();
                }
                else
                {
                    Story.AddEvent<BaseStation_Go_Find_Trash_Bathroom_Hurry>();
                }
            };
        }
    }
}

public class BaseStation_Dispose_Phone_B_Jen_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Welcome home.";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("EMPTY CONTAINER");
            choice.OnChoiceSelected += (Choice c) =>
            {
                Story.AddEvent<BaseStation_Dispose_Phone_B_Jen_2>();
            };
        }
    }
}

public class BaseStation_Dispose_Phone_B_Jen_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "Jen's phone goes *shoop*";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Phone_B_Jen = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Capsules_B;
                var item_state_b = State.State_Vape;

                if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    Story.AddEvent<BaseStation_Interaction_Return>();
                }
                else
                {
                    Story.AddEvent<BaseStation_Go_Find_Trash_Bathroom_Hurry>();
                }

            };
        }
    }
}

public class BaseStation_Dispose_Vape_1 : EventBase
{
    public override void StartEvent()
    {
        Text = "Welcome home.";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("EMPTY CONTAINER");
            choice.OnChoiceSelected += (Choice c) =>
            {
                Story.AddEvent<BaseStation_Dispose_Vape_2>();
            };
        }
    }
}
public class BaseStation_Dispose_Vape_2 : EventBase
{
    public override void StartEvent()
    {
        Text = "The vape goes *shoop*";
        ConversationActor = Actors.AI_BaseStation();

        {
            var choice = NewEventChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Vape = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Phone_B_Jen;
                var item_state_b = State.State_Capsules_B;

                if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    Story.AddEvent<BaseStation_Interaction_Return>();
                }
                else
                {
                    Story.AddEvent<BaseStation_Go_Find_Trash_Bathroom_Hurry>();
                }
            };
        }
    }
}


public class BaseStation_Go_Find_Trash_Bathroom_Hurry : EventBase
{
    public override void StartEvent()
    {
        Text = "Despite me not experiencing time I still find you slow. ";
        ConversationActor = Actors.AI_Alinna();

        {
            var choice = NewEventChoice("[embarrassed] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                Story.AddEvent<BaseStation_Interaction_Return>();
            };
        }
    }
}

