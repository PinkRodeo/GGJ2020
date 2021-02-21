using UnityEngine;

public class BaseStation_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "This is your Home Station, where the trash goes and you live.";
        EventActor = Actors.AI_Alinna();
        StoryManager.CloseCurrentEvent();

        if (State.State_Capsules_A == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Capsules_A_1>();
        }
        else if (State.State_Headset == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Headset_1>();
        }
        else if (State.State_Phone_A_Scott == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Phone_A_Scott_1>();
        }
        else if (State.State_Shoes == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Shoes_1>();
        }
        else if (State.State_Capsules_B == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Capsules_B_1>();
        }
        else if (State.State_Phone_B_Jen == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Phone_B_Jen_1>();
        }
        else if (State.State_Vape == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Vape_1>();
        }
        else if (State.IntroState == E_AlinnaState.PsychoAIRevealed)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Vacuum_1>();
        }
        else
        {
            switch (State.CleanupState)
            {
                case E_CleanupState.LivingRoomDirty:
                    StoryManager.AddNextEvent<BaseStation_Go_Find_Trash_Livingroom>();
                    break;
                case E_CleanupState.BedroomDirty:
                    StoryManager.AddNextEvent<BaseStation_Go_Find_Trash_Bedroom>();
                    break;
                case E_CleanupState.BathroomDirty:
                    StoryManager.AddNextEvent<BaseStation_Go_Find_Trash_Bathroom>();
                    break;
                case E_CleanupState.EverythingClean:
                    Debug.LogError("This should not be encountered.");
                    break;
                default:
                    break;
            }
        }
    }
}

public class BaseStation_Interaction_Return : Event
{
    public override void PlayEvent()
    {
        Text = "This is your Home Station, where the trash goes and you live.";
        EventActor = Actors.AI_Alinna();
        StoryManager.CloseCurrentEvent();

        if (State.State_Capsules_A == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Capsules_A_1>();
        }
        else if (State.State_Headset == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Headset_1>();
        }
        else if (State.State_Phone_A_Scott == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Phone_A_Scott_1>();
        }
        else if (State.State_Shoes == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Shoes_1>();
        }
        else if (State.State_Capsules_B == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Capsules_B_1>();
        }
        else if (State.State_Phone_B_Jen == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Phone_B_Jen_1>();
        }
        else if (State.State_Vape == E_ThrowawayState.PickedUp)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Vape_1>();
        }
        else if (State.IntroState == E_AlinnaState.PsychoAIRevealed)
        {
            StoryManager.AddNextEvent<BaseStation_Dispose_Vacuum_1>();
        }
    }
}

public class BaseStation_Dispose_Vacuum_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Thank you for your services";
        EventActor = Actors.AI_Alinna();

        NewContinueChoice();
    }
}

public class BaseStation_Go_Find_Trash_Livingroom : Event
{
    public override void PlayEvent()
    {
        Text = "You just woke up. Come on little dancer, we have work to do.";
        EventActor = Actors.AI_Alinna();

        NewChoice("[sleepy] affirmative.");
    }
}

public class BaseStation_Go_Find_Trash_Bedroom : Event
{
    public override void PlayEvent()
    {
        Text = "You still have work to do. Chop chop. ";
        EventActor = Actors.AI_Alinna();

        NewChoice("[diligent] affirmative.");
    }
}

public class BaseStation_Go_Find_Trash_Bathroom : Event
{
    public override void PlayEvent()
    {
        Text = "By heliOS, hurry!";
        EventActor = Actors.AI_Alinna();

        NewChoice("[hurried] affirmative.");
    }
}

public class BaseStation_Dispose_Capsules_A_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Welcome home.";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("DISPOSE WASTE");
            choice.AddNextEvent<BaseStation_Dispose_Capsules_A_2>();
        }
    }
}

public class BaseStation_Dispose_Capsules_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Capsules go *shoop*";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Capsules_A = E_ThrowawayState.ThrownInHomeStation;
                StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
            };
        }
    }
}

public class BaseStation_Dispose_Headset_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Welcome home.";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("DISPOSE WASTE");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Dispose_Headset_2>();
            };
        }
    }
}

public class BaseStation_Dispose_Headset_2 : Event
{
    public override void PlayEvent()
    {
        Text = "VR Headset goes *shoop*";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Headset = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Phone_A_Scott;
                var item_state_b = State.State_Shoes;

                if (item_state_a == E_ThrowawayState.OnFloor || item_state_b == E_ThrowawayState.OnFloor && item_state_a != E_ThrowawayState.PickedUp && item_state_b != E_ThrowawayState.PickedUp)
                {
                    StoryManager.AddNextEvent<BaseStation_Dispose_Bedroom_Half_1>();
                }
                else if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}

public class BaseStation_Dispose_Phone_A_Scott_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Welcome home.";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("DISPOSE WASTE");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Dispose_Phone_A_Scott_2>();
            };
        }
    }
}

public class BaseStation_Dispose_Phone_A_Scott_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Scott's phone goes *shoop*";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Phone_A_Scott = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Shoes;
                var item_state_b = State.State_Headset;

                if (item_state_a == E_ThrowawayState.OnFloor || item_state_b == E_ThrowawayState.OnFloor && item_state_a != E_ThrowawayState.PickedUp && item_state_b != E_ThrowawayState.PickedUp)
                {
                    StoryManager.AddNextEvent<BaseStation_Dispose_Bedroom_Half_1>();
                }
                else if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}

public class BaseStation_Dispose_Shoes_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Welcome home.";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("DISPOSE WASTE");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Dispose_Shoes_2>();
            };
        }
    }
}

public class BaseStation_Dispose_Shoes_2 : Event
{
    public override void PlayEvent()
    {
        Text = "SHOES go *shoop*";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Shoes = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Headset;
                var item_state_b = State.State_Phone_A_Scott;

                if (item_state_a == E_ThrowawayState.OnFloor || item_state_b == E_ThrowawayState.OnFloor && item_state_a != E_ThrowawayState.PickedUp && item_state_b != E_ThrowawayState.PickedUp)
                {
                    StoryManager.AddNextEvent<BaseStation_Dispose_Bedroom_Half_1>();
                }
                else if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}

public class BaseStation_Dispose_Bedroom_Half_1 : Event
{
    public override void PlayEvent()
    {
        Text = "er ligt nog iets op de grond";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[determined] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
            };
        }
    }
}

public class BaseStation_Dispose_Capsules_B_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Welcome home.";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("DISPOSE WASTE");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Dispose_Capsules_B_2>();
            };
        }
    }
}

public class BaseStation_Dispose_Capsules_B_2 : Event
{
    public override void PlayEvent()
    {
        Text = "The capsules go *shoop*";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Capsules_B = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Phone_B_Jen;
                var item_state_b = State.State_Vape;

                if (item_state_a == E_ThrowawayState.OnFloor || item_state_b == E_ThrowawayState.OnFloor && item_state_a != E_ThrowawayState.PickedUp && item_state_b != E_ThrowawayState.PickedUp)
                {
                    StoryManager.AddNextEvent<BaseStation_Go_Find_Trash_Bathroom_Hurry>();
                }
                else if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}

public class BaseStation_Dispose_Phone_B_Jen_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Welcome home.";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("DISPOSE WASTE");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Dispose_Phone_B_Jen_2>();
            };
        }
    }
}

public class BaseStation_Dispose_Phone_B_Jen_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Jen's phone goes *shoop*";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Phone_B_Jen = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Capsules_B;
                var item_state_b = State.State_Vape;

                if (item_state_a == E_ThrowawayState.OnFloor || item_state_b == E_ThrowawayState.OnFloor && item_state_a != E_ThrowawayState.PickedUp && item_state_b != E_ThrowawayState.PickedUp)
                {
                    StoryManager.AddNextEvent<BaseStation_Go_Find_Trash_Bathroom_Hurry>();
                }
                else if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}

public class BaseStation_Dispose_Vape_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Welcome home.";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("DISPOSE WASTE");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Dispose_Vape_2>();
            };
        }
    }
}
public class BaseStation_Dispose_Vape_2 : Event
{
    public override void PlayEvent()
    {
        Text = "The vape goes *shoop*";
        EventActor = Actors.AI_BaseStation();

        {
            var choice = NewChoice("[relieved] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Vape = E_ThrowawayState.ThrownInHomeStation;

                var item_state_a = State.State_Phone_B_Jen;
                var item_state_b = State.State_Capsules_B;

                if (item_state_a == E_ThrowawayState.OnFloor || item_state_b == E_ThrowawayState.OnFloor && item_state_a != E_ThrowawayState.PickedUp && item_state_b != E_ThrowawayState.PickedUp)
                {
                    StoryManager.AddNextEvent<BaseStation_Go_Find_Trash_Bathroom_Hurry>();
                }
                else if (item_state_a == E_ThrowawayState.PickedUp || item_state_b == E_ThrowawayState.PickedUp ||
                    item_state_a == E_ThrowawayState.ThrownInHomeStation || item_state_b == E_ThrowawayState.ThrownInHomeStation)
                {
                    StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
                }
            };
        }
    }
}

public class BaseStation_Go_Find_Trash_Bathroom_Hurry : Event
{
    public override void PlayEvent()
    {
        Text = "Despite me not experiencing time I still find you slow. ";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[embarrassed] affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                StoryManager.AddNextEvent<BaseStation_Interaction_Return>();
            };
        }
    }
}
