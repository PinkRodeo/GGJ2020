using UnityEngine;

public class StartEventReward<T> : RewardBase where T : Event
{
	public override void RunReward()
	{
		var newEvent = EventHelper.CreateEventByType(typeof(T));
		Story.AddNextEvent(newEvent);
	}
}
