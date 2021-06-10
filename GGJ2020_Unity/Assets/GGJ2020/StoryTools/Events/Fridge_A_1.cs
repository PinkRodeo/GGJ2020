// First conversation line with AI_Fridge
public class Fridge_A_1 : Event
{
    public override void PlayEvent()
    {
        Text = "[disheartened] Fridger 2.0 keeps the freshness...\n\nOh, why bother.";
        EventActor = Actors.AI_Fridge();

        {
            var choiceA = NewChoice("CONTINUE");
            choiceA.AddNextEvent<Fridge_A_2>();
        }
    }
}

public class Fridge_A_2 : Event
{
    public override void PlayEvent()
    {
        Text = "[cautious] My data hasn’t been accessed in weeks. Are you sure you want to continue?";
        EventActor = Actors.AI_Fridge();

        {
            var choiceA = NewChoice("LEAVE");
            choiceA.AddNextEvent<Fridge_A_2_Leave>();
        }

        {
            var choiceB = NewChoice("CONTINUE");
            choiceB.AddNextEvent<Fridge_A_2_Access_Expired>();
        }
    }
}

public class Fridge_A_2_Leave : Event
{
    public override void PlayEvent()
    {
        Text = "[sad] I’m not that interesting anyway.";
        EventActor = Actors.AI_Fridge();

        NewContinueChoice();
    }
}



public class Fridge_A_2_Access_Expired : Event
{
    public override void PlayEvent()
    {
        Text = "[warning] Many products have an 'expired' status. Are you sure you want to see this?";
        EventActor = Actors.AI_Fridge();

        {
            var choiceA = NewChoice("LEAVE");
            choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Leave>();
        }

        {
            var choiceA = NewChoice("CONTINUE");
            choiceA.AddNextEvent<Fridge_A_2_Access_Expired_Final>();
        }
    }
}

public class Fridge_A_2_Access_Expired_Leave : Event
{
    public override void PlayEvent()
    {
        Text = "[sad] Please don't go... \n\nGoo... Goodbye.";
        EventActor = Actors.AI_Fridge();

        NewContinueChoice();
    }
}

public class Fridge_A_2_Access_Expired_Final : Event
{
    public override void PlayEvent()
    {
        Text = "[blushing] Do you really think I’m cool enough? Well... Thank you.";
        EventActor = Actors.AI_Fridge();

        {
            var choiceA = NewChoice("ACCESS FRIDGE DATA");
            choiceA.AddNextEvent<Fridge_B_1_Access_Menu>();

            choiceA.OnChoiceSelected += (Choice c) =>
            {
                State.FridgeState = E_FridgeState.AccessUnlocked;
            };
        }
    }
}
