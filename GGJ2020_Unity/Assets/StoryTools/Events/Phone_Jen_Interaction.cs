
using UnityEngine;

public class Phone_Jenn_Interaction : EventBase
{
    public override void StartEvent()
    {
        Text = "This is Jen's Phone. How can I help you?";
        ConversationActor = Actors.Phone_Jen();

        {
            var choice = NewEventChoice();
            choice.Text = "CALLS";
            choice.AddReward<StartEventReward<Call1>>();

            var Messages = NewEventChoice();
            Messages.Text = "MESSAGES";
            Messages.AddReward<StartEventReward<Message1>>();

            var Settings = NewEventChoice();
            Messages.Text = "SETTINGS";
            Messages.AddReward<StartEventReward<Settings>>();
        }
    }
}


public class Call1 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "CALL DATA: SCOTT [MISSED CALL]/n" +
        "13 - 07 - 2065 | 04:32 | VOICEMAIL RECORDED/n" +
        "analyze audio file:/n" +

        "Message recorded 13th of July at 04:32, from Scott./n";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Call1B>>();
    }
}

public class Call1B : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "Jen. I am so sorry about… about everything. I know I haven’t been there. There’s no excuse for missing out, and dinner last… [sighs] two weeks ago. My mind was somewhere else, you know. But I will be here now. I’m done with the VR stuff, the glass, with Alinna. You were always there, I see that now. When are you home? I will cook. No pizza, I promise. Jen? I didn’t know you were home. [phone falls] Jen?!" +
            "/nMessage ended at 04:34.";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Call2>>();
    }
}

public class Call2 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "CALL DATA: SCOTT [UNANSWERED CALL]/n" +
        "01 - 07 - 2065 | 17:14";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Call3>>();
    }
}

public class Call3 : EventBase
{   
    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "CALL DATA: SCOTT [UNANSWERED CALL]/n" +
        "01 - 07 - 2065 | 17:31";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Call4>>();
    }
}

public class Call4 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "CALL DATA: SCOTT [UNANSWERED CALL] /n" +
"01 - 07 - 2065 | 17:58";

        var choice = NewEventChoice();
        choice.Text = "Return";
        choice.AddReward<StartEventReward<Phone_Jenn_Interaction>>();
    }
}


public class Message1 : EventBase
{
    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 6: SUSAN [UNREAD] /n" +
        "12 - 07 - 2065 | 09:12 /n" +
        "You didn’t join Scott did you? Jen you’re too pretty to be laying in bed all day, staring into The Glass. Call me. Today!";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Message2>>();
    }
}

public class Message2 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 5: SUSAN [UNREAD] /n" +
        "07-07-2065 | 14:23 /n" +
        "Worst idea ever. I will quit alcohol for a while. See what happens when you’re not around. Everything ok though?";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Message3>>();
    }
}
public class Message3 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 4: SUSAN [UNREAD] /n" +
        "06-07-2065 | 22:29 /n" +
        "JEN!!! Drinks my place! Now! Your sleeper husband won’t even know, you’ll be back before he wakes up. Haha! Get it. Heard from the guy from last week? Details?! See you in a bit.";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Message4>>();
    }
}
public class Message4 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 3: SUSAN [UNREAD] /n" +
        "04-07-2065 | 21:04 /n" +
        "Hi green eyes, was fun last weekend. I’m out again. Want to meet? Maybe we can end up at your place next time. ";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Message5>>();
    }
}

public class Message5 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "OPEN MESSAGE 1: SUSAN [UNREAD] /n" +
        "02-07-2065 | 04:54 /n" +
        "Hello Jennette, I am very sorry to hear you are having a difficult day. Your requested capsules are on their way. The bath is ready. Hope they make you feel better. I am always here to talk. Have a good night Jennette. Looking forward to seeing you home safely. ";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<Phone_Jenn_Interaction>>();
    }
}

public class Settings : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "";

        var choice = NewEventChoice();
        choice.Text = "ERASE USER DATA";
        choice.AddReward<StartEventReward<EraseUserData>>();

    }
}
public class EraseUserData : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "System: All messages and call data will be erased./n/n" +
            " Are you sure you want to proceed?";

        var choice = NewEventChoice();
        choice.Text = "PROCEED";
        choice.AddReward<StartEventReward<EraseUserDataProceed>>();

    }
}

public class EraseUserDataProceed : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.Phone_Jen();
        Text = "Please wait when your memories are being erased… Done. /nYour phone is a clean slate.";

        var choice = NewEventChoice();
        choice.Text = "...";
        choice.AddReward<StartEventReward<EraseUserDataProceed2>>();

        
    }
}

public class EraseUserDataProceed2 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.AI_Alinna();
        Text = "heliOS won’t have to worry about this one any longer.";

        var choice = NewEventChoice();
        choice.Text = "[confused] affirmative.";
        choice.AddReward<StartEventReward<EraseUserDataProceed3>>();
    }
}

public class EraseUserDataProceed3 : EventBase
{

    public override void StartEvent()
    {
        ConversationActor = Actors.AI_Alinna();
        Text = "Just talking to myself, little dancer. Take the phone and dispose of it. NOW!";

        var choice = NewEventChoice();
        choice.Text = "...";
        //choice.AddReward<StartEventReward<Phone_Jenn_Interaction>>();
        choice.OnChoiceSelected += (Choice c) =>
        {
            State.State_Phone_B_Jen = E_ThrowawayState.PickedUp;
        };
    }
}