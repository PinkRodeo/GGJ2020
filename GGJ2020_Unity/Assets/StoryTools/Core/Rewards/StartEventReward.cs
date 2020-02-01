using UnityEngine;

public class StartEventReward<T> : RewardBase where T : EventBase
{
    public override void RunReward()
    {
        var newEvent = EventHelper.CreateEventByType(typeof(T));
        Story.AddEvent(newEvent);   
    }
}
