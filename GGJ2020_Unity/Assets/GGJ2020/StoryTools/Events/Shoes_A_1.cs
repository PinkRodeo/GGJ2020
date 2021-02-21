public class Shoes_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "This is SHOES. How can I help you?";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("CALLS");
            choice.AddNextEvent<Shoes_CALLS_1>();
        }
        {
            var choice = NewChoice("MESSAGES");
            choice.AddNextEvent<Shoes_MESSAGES_1>();
        }
        {
            var choice = NewChoice("SETTINGS");
            choice.AddNextEvent<Shoes_SETTINGS_1>();
        }
    }
}

public class Shoes_MESSAGES_1 : Event
{
    public override void PlayEvent()
    {
        Text = "OPEN MESSAGE 7:\n13-07-2065 | 03:23\nUser Scott! The update came. I copied it for you: Great news, we’ve completed the analysis for your soul mate creation in the “Perfect Partner” program on “The Glass” Virtual Reality equipment. Return to your device as soon as possible to meet your future! I’m so excited for you, and the result is quite the reveal if I dare say. See you soon User Scott.";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_MESSAGES_2>();
        }
    }
}

public class Shoes_MESSAGES_2 : Event
{
    public override void PlayEvent()
    {
        Text = "OPEN MESSAGE 6: FLYING DOUGH delivery\n12-07-2065 | 22:13\nCheck your front door/balcony/roof. You CHICKEN BBQ PIZZA has arrived at your residence. 400 credits will be subtracted from your account upon opening from the package.";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_MESSAGES_3>();
        }
    }
}

public class Shoes_MESSAGES_3 : Event
{
    public override void PlayEvent()
    {
        Text = "OPEN MESSAGE 5: FLYING DOUGH delivery.\n11-07-2065 | 03:54\nCheck your front door/balcony/roof. You PEPPERONI PIZZA has arrived at your residence. 300 credits will be subtracted from your account upon opening from the package. ";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_MESSAGES_4>();
        }
    }
}

public class Shoes_MESSAGES_4 : Event
{
    public override void PlayEvent()
    {
        Text = "OPEN MESSAGE 4: JEN [UNREAD]\nREALLY? Food is cold. And your double order has arrived. Nice of you to think for both of us. Pepperoni, your favorite. You can see your dinner from the balcony if you’re looking for it. I’m out for the night. ";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_MESSAGES_5>();
        }
    }
}

public class Shoes_MESSAGES_5 : Event
{
    public override void PlayEvent()
    {
        Text = "OPEN MESSAGE 2: PERFECT PARTNER\n01-07-2065 | 11:52\nWe’re getting closer to the perfect match. Our latest iteration of your partner has improved your match by 3%, crossing the 90% line. The preferred green eye color and birthmarks help us greatly. Now for the last 10%!";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_MESSAGES_6>();
        }
    }
}

public class Shoes_MESSAGES_6 : Event
{
    public override void PlayEvent()
    {
        Text = "OPEN MESSAGE 1: JEN [UNREAD]\n01-07-2065 | 09:13\nHi. Haven’t seen you for a while. How about dinner, just us. And something not out of a box or from the sky. Thai grill? Will be ready at 5. Love you.";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_Interaction>();
        }
    }
}

public class Shoes_CALLS_1 : Event
{
    public override void PlayEvent()
    {
        Text = "CALL DATA: EMERGENCY SERVICES\n13-07-2065 | 04:53";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_CALLS_2>();
        }
    }
}

public class Shoes_CALLS_2 : Event
{
    public override void PlayEvent()
    {
        Text = "CALL DATA: [speeddial 2] JEN [UNANSWERED]\n\n13-07-2065 | 04:32 | VOICEMAIL RECORDED\nMessage recorded 13th of July at 04:32, from Scott.";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("ANALYZE AUDIO FILE");
            choice.AddNextEvent<Shoes_CALLS_3>();
        }
    }
}

public class Shoes_CALLS_3 : Event
{
    public override void PlayEvent()
    {
        Text = "Jen. I am so sorry about… about everything. I know I haven’t been there. There’s no excuse for missing out, and dinner last… [sighs] two weeks ago. My mind was somewhere else, you know. But I will be here now. I’m done with the VR stuff, the glass, with Alinna. You were always there, I see that now. When are you home? I will cook. No pizza, I promise. Jen? I didn’t know you were home. [phone falls] Jen?!\n\nMessage ended at 04:34.";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_CALLS_4>();
        }
    }
}


public class Shoes_CALLS_4 : Event
{
    public override void PlayEvent()
    {
        Text = "CALL DATA: [speeddial 1] FLYING DOUCH pizza delivery\n12-07-2065 | 21:59";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_CALLS_5>();
        }
    }
}

public class Shoes_CALLS_5 : Event
{
    public override void PlayEvent()
    {
        Text = "CALL DATA: [speeddial 1] FLYING DOUCH pizza delivery\n11-07-2065 | 03:23";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_CALLS_6>();
        }
    }
}

public class Shoes_CALLS_6 : Event
{
    public override void PlayEvent()
    {
        Text = "CALL DATA: [speeddial 1] FLYING DOUCH pizza delivery\n01-07-2065 | 17:34";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_Interaction>();
        }
    }
}

public class Shoes_SETTINGS_1 : Event
{
    public override void PlayEvent()
    {
        Text = "SETTINGS";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("ERASE USER DATA");
            choice.AddNextEvent<Shoes_SETTINGS_2>();
        }
    }
}

public class Shoes_SETTINGS_2 : Event
{
    public override void PlayEvent()
    {
        Text = "All messages and call data will be erased. Are you sure you want to proceed?";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("PROCEED");
            choice.AddNextEvent<Shoes_SETTINGS_3_A>();
        }
        {
            var choice = NewChoice("CANCEL");
            choice.AddNextEvent<Shoes_SETTINGS_3_B>();
        }
    }
}

public class Shoes_SETTINGS_3_A : Event
{
    public override void PlayEvent()
    {
        Text = "Please wait when your memories are being erased…\nDone.\nYour phone is a clean slate. ";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_SETTINGS_3_A_ERASED>();
        }
    }
}

public class Shoes_SETTINGS_3_A_ERASED : Event
{
    public override void PlayEvent()
    {
        Text = "That’s a big one from the list. Quite the cleaner you prove to be. Now dispose of the SHOES at your Home Station.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Shoes = E_ThrowawayState.PickedUp;
            };
        }
    }
}

public class Shoes_SETTINGS_3_B : Event
{
    public override void PlayEvent()
    {
        Text = "Hold on when we cancel your reque-*bzzt*.\nDone.\n\nAll your memories are erased. Your phone is a clean slate. ";
        EventActor = Actors.Shoes();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<Shoes_SETTINGS_3_A_ERASED>();
        }
    }
}
