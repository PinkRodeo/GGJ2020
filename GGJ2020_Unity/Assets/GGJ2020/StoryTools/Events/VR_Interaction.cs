public class VR_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "Hey, come take a look. It'll only take a second. You won't regret it. This is great. Trust me. ";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("PROGRAMS");
            choice.AddNextEvent<VR_Interaction_A_1>();
            // choice.OnChoiceSelected += (Choice c) => {
            //     State.State_Headset = E_ThrowawayState.PickedUp;
            // };
        }
        {
            var choice = NewChoice("UPDATES");
            choice.AddNextEvent<VR_Interaction_B_1>();
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
        Text = "“PERFECT PARTNER: Looking for that one and only, soul mate, or legendary spark. \nDon’t leave it to chance, leave it to Perfect Partner. We will create your dream, based on your unique desires. Never will you have to go on the hunt for love again.”";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction_A_2>();
        }
    }
}

public class VR_Interaction_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "YOUR 100% MATCH: \nAn image is shown from a familiar figure. Bright green eyes, birthmarks on shoulders and nose, colored hair which has faded over time. ";
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
        Text = "It’s rarely the case that the final result becomes the partner the user is already with. Many use it to escape the relationship they have. It’s beautiful. Statistically close to impossible. How curious this possibility.\nReady to erase it?";
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
        Text = "UPDATE 1: 13-07-2065 | 03:23\nGreat news, we’ve completed the analysis for your soul mate creation in the “Perfect Partner” program on “VF GEAR The Glass” Virtual Reality equipment. Return to your device as soon as possible to meet your future!";
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
        Text = "UPDATE 2: 01-07-2065 | 11:52\nWe’re getting closer to the perfect match. Our latest iteration of your partner has improved your match by 3%, crossing the 90% line. The preferred green eye color and birthmarks help us greatly. Now for the last 10%!";
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
        Text = "UPDATE 3: 30-06-2065 | 23:59\nYour activity within “VR GEAR The Glass” has increased in the last month. You’ve been active for 423 hours and 28 minutes. We’re happy to award you with a platinum user status, granting you access to previously restricted corners of  “The Glass” universe. We’re looking forward to seeing you more, next month.";
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
        Text = "UPDATE 4: 10-06-2065 | 02:01\nBased on your accessive delivery of user data we’ve been able to create an accurate estimate of the physique of your Perfect Partner, getting to a 75% match on first calculation. Thank you for your active participation in the analysis phase. We will soon update your Partner according to these calculations.";
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
        Text = "UPDATE 5: 03-06-2065 | 04:40\nYour registration to “Perfect Partner” has been completed. We recommend an active user mentality of casual and adult content on “VR GEAR The Glass” applications. More data will result in the quickest way to the final partner you’ll ever need. We will update you as soon as our first calculations are complete. Happy adventuring passion seeker!";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<VR_Interaction>();
        }
    }
}

public class VR_Interaction_C_1 : Event
{
    public override void PlayEvent()
    {
        Text = "SETTINGS";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("ERASE USER DATA");
            choice.AddNextEvent<VR_Interaction_C_A_2>();
        }
        {
            var choice = NewChoice("CHANGE PROFILE DATA: [BLOCKED]");
            choice.AddNextEvent<VR_Interaction_C_B_1>();
        }
    }
}

public class VR_Interaction_C_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "All messages and call data will be erased. Are you sure you want to proceed?";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("PROCEED:");
            choice.AddNextEvent<VR_Interaction_C_B_4>();
        }
        {
            var choice = NewChoice("CANCEL:");
            choice.AddNextEvent<VR_Interaction_C_A_3>();
        }
    }
}

public class VR_Interaction_C_A_3 : Event
{
    public override void PlayEvent()
    {
        Text = "Hold on when we cancel your reque-*bzzt*. Done. All your memories are erased. Your VR GEAR The Glass is a clean slate. ";
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
        Text = "Wasn’t it clear enough?\n\nIt’s blocked. You’re better than this little dancer.";
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
        Text = "You know I can’t stay mad at you.\nCome on, let me help.";
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
        Text = "Please wait when your memories are being erased… \nDone.\nYour VR GEAR The Glass is a clean slate. ";
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
        Text = "Thanks for clearing that one, little dancer. Don't forget to bring it to your Home Station.";
        EventActor = Actors.Headset();

        {
            var choice = NewChoice("affirmative.");
            choice.OnChoiceSelected += (Choice c) =>
            {
                State.State_Headset = E_ThrowawayState.PickedUp;
            };
        }
    }
}
