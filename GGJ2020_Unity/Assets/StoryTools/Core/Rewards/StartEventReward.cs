using UnityEngine;

public class StartEventReward<T> : RewardBase where T : EventBase
{
    public override void RunReward()
    {
        Debug.Log("Starting new event");
        var newEvent = EventHelper.CreateEventByType(typeof(T));

        if (newEvent == null)
        {
            Debug.LogError("Couldn't instantiate new event");
        }

        Story.AddEvent(newEvent);   
    }
}
