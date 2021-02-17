public class Phone_Jenn_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "This is Jen's Phone. How can I help you?";
        EventActor = Actors.Phone_Jen();

        {
            var choice = NewChoice("CALLS");
            choice.AddNextEvent<Call1>();

            var Messages = NewChoice("MESSAGES");
            Messages.AddNextEvent<Message1>();

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
        Text = "CALL DATA: SCOTT [MISSED CALL]\n" +
        "13 - 07 - 2065 | 04:32 | VOICEMAIL RECORDED\n" +
        "analyze audio file:\n\n" +

        "Message recorded 13th of July at 04:32, from Scott.\n";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call1B>();
    }
}

public class Call1B : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "Jen. I am so sorry about� about everything. I know I haven�t been there. There�s no excuse for missing out, and dinner last� [sighs] two weeks ago. My mind was somewhere else, you know. But I will be here now. I�m done with the VR stuff, the glass, with Alinna. You were always there, I see that now. When are you home? I will cook. No pizza, I promise. Jen? I didn�t know you were home. [phone falls] Jen?!" +
            "\nMessage ended at 04:34.";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call2>();
    }
}

public class Call2 : Event
{

    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "CALL DATA: SCOTT [UNANSWERED CALL]\n" +
        "01 - 07 - 2065 | 17:14";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call3>();
    }
}

public class Call3 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "CALL DATA: SCOTT [UNANSWERED CALL]\n" +
        "01 - 07 - 2065 | 17:31";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call4>();
    }
}

public class Call4 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "CALL DATA: SCOTT [UNANSWERED CALL] \n" +
"01 - 07 - 2065 | 17:58";

        var choice = NewChoice("Return");
        choice.AddNextEvent<Phone_Jenn_Interaction>();
    }
}

public class Message1 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 6: SUSAN [UNREAD] \n" +
        "12 - 07 - 2065 | 09:12 \n" +
        "You didn�t join Scott did you? Jen you�re too pretty to be laying in bed all day, staring into The Glass. Call me. Today!";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message2>();
    }
}

public class Message2 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 5: SUSAN [UNREAD] \n" +
        "07-07-2065 | 14:23 \n" +
        "Worst idea ever. I will quit alcohol for a while. See what happens when you�re not around. Everything ok though?";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message3>();
    }
}
public class Message3 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 4: SUSAN [UNREAD] \n" +
        "06-07-2065 | 22:29 \n" +
        "JEN!!! Drinks my place! Now! Your sleeper husband won�t even know, you�ll be back before he wakes up. Haha! Get it. Heard from the guy from last week? Details?! See you in a bit.";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message4>();
    }
}
public class Message4 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 3: SUSAN [UNREAD] \n" +
        "04-07-2065 | 21:04 \n" +
        "Hi green eyes, was fun last weekend. I�m out again. Want to meet? Maybe we can end up at your place next time. ";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message5>();
    }
}

public class Message5 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 1: SUSAN [UNREAD] \n" +
        "02-07-2065 | 04:54 \n" +
        "Hello Jennette, I am very sorry to hear you are having a difficult day. Your requested capsules are on their way. The bath is ready. Hope they make you feel better. I am always here to talk. Have a good night Jennette. Looking forward to seeing you home safely. ";

        var choice = NewChoice("...");
        choice.AddNextEvent<Phone_Jenn_Interaction>();
    }
}

public class Settings : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "SETTINGS";

        var choice = NewChoice("ERASE USER DATA");
        choice.AddNextEvent<EraseUserData>();
    }
}
public class EraseUserData : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "System: All messages and call data will be erased.\n\n" +
            " Are you sure you want to proceed?";

        var choice = NewChoice("PROCEED");
        choice.AddNextEvent<EraseUserDataProceed>();
    }
}

public class EraseUserDataProceed : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "Please wait when your memories are being erased� Done. \nYour phone is a clean slate.";

        var choice = NewChoice("...");
        choice.AddNextEvent<EraseUserDataProceed2>();
    }
}

public class EraseUserDataProceed2 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.AI_Alinna();
        Text = "heliOS won�t have to worry about this one any longer.";

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