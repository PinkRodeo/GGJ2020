using UnityEngine;

public class StartEventReward<T> : RewardBase where T : EventBase
{
    public override void RunReward()
    {
        var newEvent = EventHelper.CreateEventByType(typeof(T));

        if (newEvent == null)
        {
            Debug.LogError("Couldn't instantiate new event");
        }

        Story.AddEvent(newEvent);   
    }
}
