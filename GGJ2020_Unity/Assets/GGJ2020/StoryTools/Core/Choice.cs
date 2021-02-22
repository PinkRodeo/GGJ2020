using System.Collections.Generic;

public class Choice
{
    public StoryChoiceDelegate OnChoiceSelected;

    public Event ParentEvent;
    private string _text;

    private List<System.Type> _rewards = new List<System.Type>();

    public bool DisplayOnEventStart = true;

    public Choice(Event parentEvent)
    {
        ParentEvent = parentEvent;
    }

    public string Text
    {
        set
        {
            _text = value;
        }
        get
        {
            return _text;
        }
    }

    public void AddReward<T>() where T : RewardBase
    {
        _rewards.Add(typeof(T));
    }

    public void RemoveReward<T>() where T : RewardBase
    {
        _rewards.Remove(typeof(T));
    }

    public void AddNextEvent<T>() where T : Event
    {
        AddReward<StartEventReward<T>>();
    }

    public void RemoveNextEvent<T>() where T : Event
    {
        RemoveReward<StartEventReward<T>>();
    }

    public void Select()
    {
        // Trigger events in the order they were added in
        _rewards.Reverse();

        foreach (var rewardType in _rewards)
        {
            var reward = EventHelper.CreateRewardByType(rewardType);
            reward.RunReward();
        }

        if (OnChoiceSelected != null)
            OnChoiceSelected(this);
    }
}
