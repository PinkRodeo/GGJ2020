public class Phone_Scott_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "This is Scott's Phone. How can I help you?";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("MESSAGES [2 UNREAD]");
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
        Text = "14-JUL-2065 | 01:23 | FROM: ALINNA\n\nScott! Your PERFECT PARTNER update came in, I’m so excited for you! The result is quite the reveal if I dare say ;)";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_2>();
        }
    }
}

public class Phone_Scott_MESSAGES_2 : Event
{
    public override void PlayEvent()
    {
        Text = "12-JUL-2065 | 22:13 | FROM: FLYING DOUGH PIZZA\n\nCheck your front door/balcony/roof. Your CHICKEN BBQ PIZZA has arrived at your residence. 400 credits will be charged to your account.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_4>();
        }
    }
}

public class Phone_Scott_MESSAGES_3 : Event
{
    public override void PlayEvent()
    {
        Text = "07-JUL-2065 | 03:54 | FROM: FLYING DOUGH PIZZA\n\nCheck your front door/balcony/roof. Your PEPPERONI PIZZA has arrived at your residence. 300 credits will be charged to your account.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_5>();
        }
    }
}

public class Phone_Scott_MESSAGES_4 : Event
{
    public override void PlayEvent()
    {
        Text = "03-JUL-2065 | 03:56 | FROM: JEN [UNREAD]\n\nREALLY?! the food i made for u is cold. and your pizza order fell of the balcony. nice of you to think for the both of us. im out for the night";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Phone_Scott_MESSAGES_3>();
        }
    }
}

public class Phone_Scott_MESSAGES_5 : Event
{
    public override void PlayEvent()
    {
        Text = "02-JUL-2065 | 11:52 | FROM: PERFECT PARTNER\n\nThanks for signing up for the PERFECT PARTNER program. We will not disappoint you.";
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
        Text = "01-JUL-2065 | 09:13 | FROM: JEN [UNREAD]\n\nhey. where have u been? how about i make dinner, just us. something that's not out of a box from the sky. i'll make Thai grill. will be ready at 7. love you :)";
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
        Text = "13-JUL-2065 | 04:54 | EMERGENCY SERVICES [UNANSWERED] | RECORDING AVAILABLE\n\nSir? Sir we are on our way to your apartment. Please stay calm. We are on our way.";
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
        Text = "03-JUL-2065 | 06:23 | FROM: JEN [UNANSWERED] | RECORDING AVAILABLE\n\n[slurring] I hope you found your cold dinner nice. Next time I won't even bother making something for you.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("RETURN");
            choice.AddNextEvent<Phone_Scott_Interaction>();
        }
    }
}

public class Phone_Scott_CALLS_3 : Event
{
    public override void PlayEvent()
    {
        Text = "[slurring] I hope you found your cold dinner nice. Next time I won't even bother making something for you.";
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
    }
}

public class Phone_Scott_SETTINGS_3_A : Event
{
    public override void PlayEvent()
    {
        Text = "Please wait while your memories are being erased…\n\nDone. Your phone is a clean slate.";
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
        Text = "Hold on while we cancel your reque-*bzzt*. \n\nDone. All your memories are erased. Your phone is a clean slate.";
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
        Text = "That’s a big one from the list. Quite the cleaner you prove to be. Now dispose of the phone at your Base Station.";
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
