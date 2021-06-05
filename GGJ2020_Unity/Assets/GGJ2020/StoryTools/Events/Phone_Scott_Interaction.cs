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
            var choice = NewChoice("CALLS [1 RECORDED]");
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
        Text = "13-JUL-2065 | 03:23 | ALINNA\n\nScott! Your PERFECT PARTNER update came in, so I copied it for you:\n\nGreat news, we’ve completed the analysis for your soul mate creation in the PERFECT PARTNER program on Glass VR. Return to your device as soon as possible to meet your future!\n\nI’m so excited for you, and the result is quite the reveal if I dare say ;)";
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
        Text = "12-JUL-2065 | 22:13 | FLYING DOUGH PIZZA\n\nCheck your front door/balcony/roof. Your CHICKEN BBQ PIZZA has arrived at your residence. 400 credits will be charged to your account.";
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
        Text = "05-JUL-2065 | 03:54 | FLYING DOUGH PIZZA\n\nCheck your front door/balcony/roof. Your PEPPERONI PIZZA has arrived at your residence. 300 credits will be charged to your account.";
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
        Text = "03-JUL-2065 | 03:56 | JEN [UNREAD]\n\nREALLY?! the food i made for u is cold. and your pizza order fell of the balcony. nice of you to think for the both of us. im out for the night";
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
        Text = "02-JUL-2065 | 11:52 | PERFECT PARTNER\n\nThanks for signing up for the PERFECT PARTNER program. We will not disappoint you.";
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
        Text = "01-JUL-2065 | 09:13 | JEN [UNREAD]\n\nhey. where have u been? how about i make dinner, just us. something that's not out of a box from the sky. i'll make Thai grill. will be ready at 7. love you :)";
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
        Text = "13-JUL-2065 | 04:54 | EMERGENCY SERVICES\n\nNO DATA";
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
        Text = "14-JUL-2065 | 06:32 | SCOTT to JEN [UNANSWERED]\n\nRECORDING AVAILABLE";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("LISTEN");
            choice.AddNextEvent<Phone_Scott_CALLS_3>();
        }
    }
}

public class Phone_Scott_CALLS_3 : Event
{
    public override void PlayEvent()
    {
        Text = "...Jen. I am so sorry about… about everything. I know I haven’t been there. There’s no excuse for missing out, and dinner last… [sighs] two weeks ago. My mind was somewhere else, you know. But I will be here now. I’m done with the VR stuff, the glass, with Alinna. You were always there, I see that now. When are you home? I will cook. No pizza, I promise. [footsteps] Jen? I didn’t know you were home... [phone falls] Jennette?! JEN!";
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
