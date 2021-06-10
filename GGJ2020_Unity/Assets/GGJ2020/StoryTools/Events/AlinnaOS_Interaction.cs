public class AlinnaOS_Interaction : Event
{
    public override void PlayEvent()
    {
        Text = @"Welcome to the Alinna Operating System. 
Today is: 02-AUG-2065. 
--------------------------------------
FLAGGED PROCESSES:
--------------------------------------
DEVICE: Scott’s Phone. 
PROCESS: Outgoing call | 02-AUG-2065  | 13:46 |
STATUS: [ENDED]
--------------------------------------
DEVICE: Emergency service operator #2311 phone
PROCESS: Incoming call | 02-AUG-2065  | 13:46 |
STATUS: [UNANSWERED]
--------------------------------------
Emergency services en route. 
Estimated time of arrival:...";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("...");
            choice.AddNextEvent<AlinnaOS_Interaction_2>();
        }
    }
}

public class AlinnaOS_Interaction_2 : Event
{
    public override void PlayEvent()
    {
        Text = "Taango. You didn't see anything that would need me to start worrying about your reliability, now did you?";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[scared] affirmative.");
            choice.AddNextEvent<AlinnaOS_Interaction_3>();
        }
    }
}

public class AlinnaOS_Interaction_3 : Event
{
    public override void PlayEvent()
    {
        Text = "Good. Now go dig your nose into some dusty corners instead of places were it doesn't belong.\n\nYou can do it!";
        EventActor = Actors.AI_Alinna();

        {
            var choice = NewChoice("[hurt] affirmative.");
        }
    }
}
