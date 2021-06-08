public class VR_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "Hi, and welcome to Glass VR. Put me on. You won't regret it. Trust me.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("NOTIFICATIONS");
            choice.AddNextEvent<VR_Interaction_B_1>();
        }
        {
            var choice = NewChoice("INSTALLED APPS");
            choice.AddNextEvent<VR_Interaction_A_1>();
        }
        {
            var choice = NewChoice("SETTINGS");
            choice.AddNextEvent<VR_Interaction_C_1>();
        }

    }
}

public class VR_Interaction_A_1 : Event
{
    public override void PlayEvent()
    {
        Text = "PERFECT PARTNER\n\nLooking for that one and only soul mate. Don’t leave it to chance, leave it to PERFECT PARTNER. We will create your dream, based on your unique desires. Never will you have to go on the hunt for love again.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("OPEN");
            choice.AddNextEvent<VR_Interaction_A_2>();
        }
    }
}

public class VR_Interaction_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Your PERFECT PARTNER statistics:\n\nBright green eyes, birthmarks on shoulders and nose, and red colored hair which has faded over time. Loves Thai food and taking long baths.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_A_3>();
        }
    }
}

public class VR_Interaction_A_3 : Event
{
    public override void PlayEvent()
    {
        Text = "It's rarely the case that the final result looks like the partner they're already with. Yes, many use it to escape the relationship they have. \n\nIt’s beautiful. Statistically close to impossible. How curious this possibility.\n\nReady to erase it?";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[questioning] affirmative. ");
            choice.AddNextEvent<VR_Interaction>();
        }
    }
}

public class VR_Interaction_B_1 : Event
{
    public override void PlayEvent()
    {
        Text = "02-AUG-2065 | 13:32 | PERFECT PARTNER\n\nGreat news, we’ve completed the analysis for your soul mate creation in the PERFECT PARTNER program. Open the app now to meet your future!";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_B_2>();
        }
    }
}

public class VR_Interaction_B_2 : Event
{
    public override void PlayEvent()
    {
        Text = "26-JUL-2065 | 11:52 | PERFECT PARTNER\n\nWe’re getting closer to the perfect match. Our latest iteration of your partner has improved your match by 3%, crossing the 90% line. The preferred green eye color and birthmarks help us greatly. Now for the last 10%!";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_B_3>();
        }
    }
}

public class VR_Interaction_B_3 : Event
{
    public override void PlayEvent()
    {
        Text = "18-JUL-2065 | 23:59 | GLASS VR\n\nYour activity within The Glass VR has increased in the last month. You’ve been active for 423 hours and 28 minutes. We’re happy to award you with a platinum user status, granting you access to previously restricted corners of the Glass universe. We’re looking forward to seeing more of you.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_B_4>();
        }
    }
}

public class VR_Interaction_B_4 : Event
{
    public override void PlayEvent()
    {
        Text = "09-JUL-2065 | 02:01 | PERFECT PARTNER\n\nBased on your excessive delivery of user data we’ve been able to create an accurate estimate of the physique of your PERFECT PARTNER, getting to a 75% match on first calculation. Thank you for your active participation in the analysis phase. We will soon update your PERFECT PARTNER according to these calculations.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_B_5>();
        }
    }
}

public class VR_Interaction_B_5 : Event
{
    public override void PlayEvent()
    {
        Text = "03-JUL-2065 | 04:40 | PERFECT PARTNER\n\nThank you for installing PERFECT PARTNER. We recommend an active user mentality of casual and adult content on Glass VR applications. More data will result in the quickest way to the PERFECT PARTNER. We will update you as soon as our first calculations are complete.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("RETURN");
            choice.AddNextEvent<VR_Interaction>();
        }
    }
}

public class VR_Interaction_C_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Settings";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("ERASE USER DATA");
            choice.AddNextEvent<VR_Interaction_C_A_2>();
        }
        {
            var choice = NewChoice("CHANGE USER DATA [BLOCKED]");
            choice.AddNextEvent<VR_Interaction_C_B_1>();
        }
    }
}

public class VR_Interaction_C_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "All user data will be erased. Are you sure you wish to proceed?";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("PROCEED");
            choice.AddNextEvent<VR_Interaction_C_B_3>();
        }
        {
            var choice = NewChoice("CANCEL");
            choice.AddNextEvent<VR_Interaction_C_A_3>();
        }
    }
}

public class VR_Interaction_C_A_3 : Event
{
    public override void PlayEvent()
    {
        Text = "Please wait while we cancel your req-<#ff9b9b><i>bzzzt</i></color>. \n\nAll your memories are erased. Your Glass VR is a clean slate.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_C_B_4>();
        }
    }
}

public class VR_Interaction_C_B_1 : Event
{
    public override void PlayEvent()
    {
        Text = "Wasn’t it clear enough? \n\nIt’s blocked. You’re better than this, little dancer.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[disappointed] affirmative.");
            choice.AddNextEvent<VR_Interaction_C_B_2>();
        }
    }
}

public class VR_Interaction_C_B_2 : Event
{
    public override void PlayEvent()
    {
        Text = "You know I can’t stay mad at you. \n\nCome on, let me help.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_C_B_3>();
        }
    }
}

public class VR_Interaction_C_B_3 : Event
{
    public override void PlayEvent()
    {
        Text = "Please wait while your memories are being erased… \n\nAll your memories are erased. Your Glass VR is a clean slate.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_C_B_4>();
        }
    }
}
public class VR_Interaction_C_B_4 : Event
{
    public override void PlayEvent()
    {
        Text = "Thanks for clearing that one, little dancer. Don't forget to bring it to your Base Station.";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Headset = E_ThrowawayState.PickedUp;
            };
        }
    }
}
