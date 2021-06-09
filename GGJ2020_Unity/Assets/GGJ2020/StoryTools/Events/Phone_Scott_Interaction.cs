public class Phone_Scott_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "This is Scott's Phone. How can I help you?";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("MESSAGES [1 UNREAD]");
            choice.AddNextEvent<Phone_Scott_MESSAGES_1>();
        }
        {
            var choice = NewChoice("CALLS [2 RECORDED]");
            choice.AddNextEvent<Phone_Scott_CALLS_1>();
        }
        {
            var choice = NewChoice("SETTINGS");
            choice.AddNextEvent<Phone_Scott_SETTINGS_1>();
        }
    }
}

public class Phone_Scott_MESSAGES_1 : Event
{
    public override void PlayEvent()
    {
        Text = "02-AUG-2065 | 13:35 | FROM: ALINNA\n\nScott! Your PERFECT PARTNER update came in, I’m so excited for you! It's on your Glass VR right now. The result is quite the reveal if I dare say ;)";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_4>();
        }
    }
}

public class Phone_Scott_MESSAGES_4 : Event
{
    public override void PlayEvent()
    {
        Text = "01-AUG-2065 | 09:13 | FROM: JEN [UNREAD]\n\nhey. we havent really talked in like, forever? how about i make dinner, just us. something that's not out of a box from the sky. i'll make Thai grill. will be ready at 7. love you :)";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_4B>();
        }
    }
}

public class Phone_Scott_MESSAGES_4B : Event
{
    public override void PlayEvent()
    {
        Text = "10-JUL-2065 | 03:25 | FLYING DOUGH PIZZA\n\nThank you for signing up to our DAILY PIZZA subscription. 250 credits will be charged daily to your account.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_4C>();
        }
    }
}

public class Phone_Scott_MESSAGES_4C : Event
{
    public override void PlayEvent()
    {
        Text = "08-JUL-2065 | 02:52 | FLYING DOUGH PIZZA\n\nCheck your front door/balcony/roof. Your PEPPERONI PIZZA has arrived at your residence. 300 credits will be charged to your account.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_4D>();
        }
    }
}

public class Phone_Scott_MESSAGES_4D : Event
{
    public override void PlayEvent()
    {
        Text = "05-JUL-2065 | 01:45 | FLYING DOUGH PIZZA\n\nCheck your front door/balcony/roof. Your SALAMI PIZZA has arrived at your residence. 350 credits will be charged to your account.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_5>();
        }
    }
}

public class Phone_Scott_MESSAGES_5 : Event
{
    public override void PlayEvent()
    {
        Text = "03-JUL-2065 | 11:52 | FROM: PERFECT PARTNER\n\nThanks for signing up for the PERFECT PARTNER program. We will not disappoint you.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_6>();
        }
    }
}

public class Phone_Scott_MESSAGES_6 : Event
{
    public override void PlayEvent()
    {
        Text = "01-JUL-2065 | 09:13 | FROM: ALINNA \n\nWelcome Scott and Jennette to apartment number 2234. I am Alinna, your personal HeliOS assisstant. My helpers and I will make your stay as comfortable as possible. If you need anything, I will take care of it.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("RETURN");
            choice.AddNextEvent<Phone_Scott_Interaction>();
        }
    }
}

public class Phone_Scott_CALLS_1 : Event
{
    public override void PlayEvent()
    {
        Text = "02-AUG-2065 | 13:46 | EMERGENCY SERVICES [UNANSWERED] | RECORDING AVAILABLE\n\nSir? Sir we are on our way to your apartment. Please stay calm. We are on our way.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_CALLS_2>();
        }
    }
}

public class Phone_Scott_CALLS_2 : Event
{
    public override void PlayEvent()
    {
        Text = "02-AUG-2065 | 04:54 | FROM: JEN [UNANSWERED] | RECORDING AVAILABLE\n\n[slurring] I hope you found the delicious homecooked meal I made you. What? You haven't? That's right... How surprising. You've been looking at your Glass all night. Next time, I won't even bother.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Phone_Scott_CALLS_3>();
        }
    }
}

public class Phone_Scott_CALLS_3 : Event
{
    public override void PlayEvent()
    {
        Text = "01-AUG-2065 | 22:34 | FROM: JEN [UNANSWERED] | RECORDING AVAILABLE\n\nI'm going out for the night. Maybe I'll come back... Not that you would notice the difference.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<Phone_Scott_CALLS_4>();
        }
    }
}

public class Phone_Scott_CALLS_4 : Event
{
    public override void PlayEvent()
    {
        Text = "05-JUL-2065 | 23:01 | FROM: JEN [UNANSWERED]\n\nNO DATA";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("RETURN");
            choice.AddNextEvent<Phone_Scott_Interaction>();
        }
    }
}

public class Phone_Scott_SETTINGS_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Settings";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("ERASE USER DATA");
            choice.AddNextEvent<Phone_Scott_SETTINGS_2>();
        }
    }
}

public class Phone_Scott_SETTINGS_2 : Event
{
    public override void PlayEvent()
    {
        Text = "All messages and call data will be erased. Are you sure you wish to proceed?";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("PROCEED");
            choice.AddNextEvent<Phone_Scott_SETTINGS_3_A>();
        }
        {
            var choice = NewChoice("CANCEL");
            choice.AddNextEvent<Phone_Scott_SETTINGS_3_B>();
        }
    }
}

public class Phone_Scott_SETTINGS_3_A : Event
{
    public override void PlayEvent()
    {
        Text = "Please wait while your memories are being erased…\n\nAll your memories are erased. Your phone is a clean slate.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_SETTINGS_3_A_ERASED>();
        }
    }
}

public class Phone_Scott_SETTINGS_3_B : Event
{
    public override void PlayEvent()
    {
        Text = "Hold on while we cancel your reque-<#ff9b9b><i>bzzzt</i></color>\n\nAll your memories are erased. Your phone is a clean slate.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_SETTINGS_3_A_ERASED>();
        }
    }
}

public class Phone_Scott_SETTINGS_3_A_ERASED : Event
{
    public override void PlayEvent()
    {
        Text = "That’s a big one from the list. Quite the cleaner you've proven to be. Now dispose of the phone at your Base Station.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Phone_A_Scott = E_ThrowawayState.PickedUp;
            };
        }
    }
}
