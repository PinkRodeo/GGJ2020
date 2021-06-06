public class Phone_Jenn_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "This is Jen's Phone. How can I help you?";
        EventActor = Actors.Phone_Jen();

        {
            var Messages = NewChoice("MESSAGES [3 UNREAD]");
            Messages.AddNextEvent<Message1>();

            var choice = NewChoice("CALLS [3 RECORDED]");
            choice.AddNextEvent<Call1>();

            var Settings = NewChoice("SETTINGS");
            Settings.AddNextEvent<Settings>();
        }
    }
}

public class Call1 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "14-JUL-2065 | 06:32 | FROM: SCOTT [UNANSWERED] | RECORDING AVAILABLE\n\n...Jen. I am so sorry about… about everything. I know I haven’t been there. There’s no excuse for missing out, and dinner last… [sighs] two weeks ago. My mind was somewhere else, you know. But I will be here now. I’m done with the VR stuff, the glass, with Alinna. You were always there, I see that now. When are you home? I will cook. No pizza, I promise. [footsteps] Jen? I didn’t know you were home... [phone falls] Jennette?! JEN!";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call2A>();
    }
}

public class Call1B : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "14-JUL-2065 | 06:32 | FROM: SCOTT [UNANSWERED] | RECORDING AVAILABLE\n\n...Jen. I am so sorry about… about everything. I know I haven’t been there. There’s no excuse for missing out, and dinner last… [sighs] two weeks ago. My mind was somewhere else, you know. But I will be here now. I’m done with the VR stuff, the glass, with Alinna. You were always there, I see that now. When are you home? I will cook. No pizza, I promise. [footsteps] Jen? I didn’t know you were home... [phone falls] Jennette?! JEN!";
        var choice = NewChoice("...");
        choice.AddNextEvent<Call2A>();
    }
}

public class Call2A : Event
{

    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "07-JUL-2065 | 12:43 | FROM: SCOTT [UNANSWERED]\n\nNO DATA";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call2>();
    }
}

public class Call2 : Event
{

    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "05-JUL-2065 | 17:58 | FROM: SCOTT [UNANSWERED]\n\nNO DATA";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call3>();
    }
}

public class Call3 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "03-JUL-2065 | 06:23 | FROM: SCOTT [UNANSWERED] | RECORDING AVAILABLE\n\n[slurring] I hope you found your cold dinner nice. Next time I won't even bother making something for you.";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call4>();
    }
}

public class Call4 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "01-JUN-2065 | 14:34 | HOT GUY [UNANSWERED]\n\nNO DATA";

        var choice = NewChoice("RETURN");
        choice.AddNextEvent<Phone_Jenn_Interaction>();
    }
}

public class Message1 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "12-JUL-2065 | 09:12 | SUSAN [UNREAD]\n\njenn i havent heard from you in ages. you didn't join Scott, did you? Jen you're too pretty to be laying in bed like him all day, staring into his Glass. call me today!!";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message2>();
    }
}

public class Message2 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "07-JUL-2065 | 14:23 | SUSAN [UNREAD] \n\nthat was my worst idea ever. ill quit alcohol for a while. everything ok though???";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message3>();
    }
}
public class Message3 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "06-JUL-2065 | 22:29 | SUSAN [UNREAD]\n\nJEN!!! we need u!! drinks my place! now!! your sleeper husband wont even know, you'll be back before he wakes up. HAHA get it. see you in a bit.";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message4>();
    }
}
public class Message4 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "04-JUL-2065 | 04:54 | ALINNA\n\nHello Jennette, I am very sorry to hear you are having a difficult day. Your requested capsules are on their way. The bath is ready. Hope they make you feel better. I am always here to talk. Have a good night Jennette. Looking forward to seeing you home safely.";

        var choice = NewChoice("RETURN");
        choice.AddNextEvent<Message5>();
    }
}

public class Message5 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "02-JUL-2065 | 21:04 | SUSAN\n\nhhi green eyes, was fun last night. im out this evening again, wanna meet up? maybe we can end up at your place next time. dont u worry about Scott okay?";

        var choice = NewChoice("RETURN");
        choice.AddNextEvent<Phone_Jenn_Interaction>();
    }
}

public class Settings : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "Settings";

        var choice = NewChoice("ERASE USER DATA");
        choice.AddNextEvent<EraseUserData>();
    }
}
public class EraseUserData : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "All messages and call data will be erased. Are you sure you wish to proceed?";

        var choice = NewChoice("PROCEED");
        choice.AddNextEvent<EraseUserDataProceed>();
    }
}

public class EraseUserDataProceed : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "Please wait while your memories are being erased…\n\nDone. Your phone is a clean slate.";

        var choice = NewChoice("...");
        choice.AddNextEvent<EraseUserDataProceed2>();
    }
}

public class EraseUserDataProceed2 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.AI_Alinna();
        Text = "heliOS won't have to worry about this one any longer.";

        var choice = NewChoice("[confused] affirmative.");
        choice.AddNextEvent<EraseUserDataProceed3>();
    }
}

public class EraseUserDataProceed3 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.AI_Alinna();
        Text = "Just talking to myself, little dancer. Take the phone and dispose of it. NOW!";

        var choice = NewChoice("...");
        //choice.AddNextEvent<Phone_Jenn_Interaction>();
        choice.OnChoiceSelected += (Choice c) =>
        {
            State.State_Phone_B_Jen = E_ThrowawayState.PickedUp;
        };
    }
}
