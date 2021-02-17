using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event
{
    private string _text = "";

    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
        }
    }

    private Actor _eventActor;

    public Actor EventActor
    {
        get
        {
            return _eventActor;
        }
        set
        {
            _eventActor = value;
        }
    }

    public bool IsClosing
    {
        get
        {
            return _isClosing;
        }
    }

    protected static StoryState State = StoryState.Instance;
    protected static StoryManager StoryManager = global::StoryManager.Instance;

    private bool _isClosing = false;

    public List<Choice> EventChoices = new List<Choice>();

    private List<System.Type> _onCloseRewards = new List<System.Type>();

    public void AddOnCloseReward<T>() where T : RewardBase
    {
        _onCloseRewards.Add(typeof(T));
    }

    public void RemoveOnCloseReward<T>() where T : RewardBase
    {
        _onCloseRewards.Remove(typeof(T));
    }

    public Choice NewChoice()
    {
        var newChoice = new Choice(this);

        // Every Event Choice automatically gets a close current event reward
        newChoice.AddReward<CloseCurrentEventReward>();

        EventChoices.Add(newChoice);

        return newChoice;
    }

    public Choice NewChoice(string choiceText)
    {
        var newChoice = NewChoice();
        newChoice.Text = choiceText;
        return newChoice;
    }

    public Choice NewContinueChoice()
    {
        return NewChoice("…");
    }

    public Choice NewAffirmativeChoice()
    {
        return NewChoice("affirmative.");
    }

    public void DisplayChoice(Choice newChoice)
    {
        StoryManager.AddChoice(newChoice);
        newChoice.DisplayOnEventStart = false;
    }

    public abstract void PlayEvent();

    public void CloseEvent()
    {
        foreach (var rewardType in _onCloseRewards)
        {
            var reward = EventHelper.CreateRewardByType(rewardType);
            reward.RunReward();
        }

        _isClosing = true;
    }
}
