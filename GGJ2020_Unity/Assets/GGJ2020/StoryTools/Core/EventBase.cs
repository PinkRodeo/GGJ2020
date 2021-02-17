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

    private Actor _actor;

    public Actor EventActor
    {
        get
        {
            return _actor;
        }
        set
        {
            _actor = value;
        }
    }

    protected static StoryState State = StoryState.Instance;
    protected static StoryManager StoryManager = global::StoryManager.Instance;

    private bool _closing = false;

    private List<Choice> choices = new List<Choice>();

    public List<Choice> EventChoices = new List<Choice>();

    private List<System.Type> _onCloseRewards = new List<System.Type>();

    public void AddCloseReward<T>() where T : RewardBase
    {
        _onCloseRewards.Add(typeof(T));
    }

    public void RemoveCloseReward<T>() where T : RewardBase
    {
        _onCloseRewards.Remove(typeof(T));
    }


    public Choice NewEventChoice()
    {
        var newChoice = new Choice(this);

        // Every Event Choice automatically gets a close event
        newChoice.AddReward<CloseEventReward>();
        EventChoices.Add(newChoice);

        return newChoice;
    }

    public Choice NewChoice(string choiceText)
    {
        var newChoice = new Choice(this);

        // Every Event Choice automatically gets a close event
        newChoice.AddReward<CloseEventReward>();

        newChoice.Text = choiceText;
        EventChoices.Add(newChoice);

        return newChoice;
    }

    public Choice AddContinueChoice()
    {
        return NewChoice("…");
    }

    public Choice AddAffirmativeChoice()
    {
        return NewChoice("affirmative.");
    }

    public void DisplayChoice(Choice newChoice)
    {
        choices.Add(newChoice);
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

        _closing = true;
    }

    public bool IsClosing()
    {
        return _closing;
    }
}
