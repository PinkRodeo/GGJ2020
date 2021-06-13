public class Phone_Jenn_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = "This is Jen's Phone. How can I help you?";
        EventActor = Actors.Phone_Jen();

        {
            var Messages = NewChoice("MESSAGES");
            Messages.AddNextEvent<Message1>();

            var choice = NewChoice("CALLS [2 RECORDED]");
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
        Text = "02-AUG-2065 | 13:40 | FROM: SCOTT [UNANSWERED] | RECORDING AVAILABLE\n\n...Jen. I am so sorry about… about everything. I know I haven’t been there for you, for dinner. My mind was somewhere else, you know. But I’m here now. I’m done with the Glass, all of it. When will you get back? I will cook. No pizza, I promise. [footsteps] Jen? You’re home? Jennette?! [phone falls] JEN!";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call2>();
    }
}

public class Call2 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "23-JUL-2065 | 01:54 | UNKNOWN [UNANSWERED]\n\nNO DATA";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call3>();
    }
}

public class Call3 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "09-JUL-2065 | 00:32 | UNKNOWN [UNANSWERED]\n\nNO DATA";

        var choice = NewChoice("...");
        choice.AddNextEvent<Call5>();
    }
}

public class Call5 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "04-JUL-2065 | 14:34 | SUSAN | RECORDING AVAILABLE\n\nHey Jennette! Welcome to the cool side of town. Here's my number, let's have a drink sometime yeah?";

        var choice = NewChoice("RETURN");
        choice.AddNextEvent<Phone_Jenn_Interaction>();
    }
}

public class Message1 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "02-AUG-2065 | 04:58 | ALINNA\n\nHello Jennette, I am very sorry to hear you are having a difficult time. Your requested capsules are on their way, and the bath is ready. Hope it makes you feel better. I am always here to talk. Have a good night Jennette. Looking forward to seeing you home safely.";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message2>();
    }
}

public class Message2 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "01-AUG-2065 | 22:29 | SUSAN\n\nJEN!!! we need u!! drinks my place! now!! You'll be back before he wakes up. HAHA get it. see you in a bit.";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message3>();
    }
}
public class Message3 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "01-AUG-2065 | 20:13 | SUSAN\n\nJENN! i havent heard from you in ages. you didn't join Scott, did you? You're too pretty to be laying in bed like him all day. tonight, party at my place!!";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message5>();
    }
}

public class Message5 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "17-JUL-2065 | 21:04 | SUSAN\n\nhhi green eyes, was fun last night. wanna meet up? maybe we can end up at your place this time.";

        var choice = NewChoice("...");
        choice.AddNextEvent<Message6>();
    }
}

public class Message6 : Event
{
  public override void PlayEvent()
  {
    EventActor = Actors.Phone_Jen();
    Text = "01-JUL-2065 | 09:13 | FROM: ALINNA \n\nWelcome Scott and Jennette to apartment number 2234. I am Alinna, your personal HeliOS assisstant. My helpers and I will make your stay as comfortable as possible. If you need anything, I will take care of it. Welcome home.";

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

        {
          var choice = NewChoice("PROCEED");
          choice.AddNextEvent<EraseUserDataProceed_1A>();
        }
        {
          var choice = NewChoice("CANCEL");
          choice.AddNextEvent<EraseUserDataProceed_1B>();
        }
    }
}

public class EraseUserDataProceed_1A : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.Phone_Jen();
        Text = "Please wait while your memories are being erased…\n\nAll your memories are erased. Your phone is a clean slate.";

        var choice = NewChoice("...");
        choice.AddNextEvent<EraseUserDataProceed2>();
    }
}

public class EraseUserDataProceed_1B : Event
{
    public override void PlayEvent()
    {
        Text = "Hold on while we cancel your reque-<#ff9b9b><i>bzzzt</i></color>\n\nAll your memories are erased. Your phone is a clean slate.";
        EventActor = Actors.Phone_Scott();

        {
            var choice = NewChoice("…");
            choice.AddNextEvent<EraseUserDataProceed2>();
        }
    }
}

public class EraseUserDataProceed2 : Event
{
    public override void PlayEvent()
    {
        EventActor = Actors.AI_Alinna();
        Text = "HeliOS won't have to worry about this one any longer.";

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

        var choice = NewChoice("[hurried] affirmative.");
        //choice.AddNextEvent<Phone_Jenn_Interaction>();
        choice.OnChoiceSelected += (Choice c) =>
        {
            State.State_Phone_B_Jen = E_ThrowawayState.PickedUp;
        };
    }
}
