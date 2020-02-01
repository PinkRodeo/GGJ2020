using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBase
{
    protected static StoryState State = StoryState.Instance;
    protected static StoryManager Story = StoryManager.Instance;
    private string _text = "";
    private List<Choice> choices = new List<Choice>();

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

    public Actor ConversationActor
    {
        get
        {
            return  _actor;
        }
        set
        {
            _actor = value;
        }
    }

    private List<System.Type> _closeRewards = new List<System.Type>();
    
    public void AddCloseReward<T>() where T : RewardBase
    {
        _closeRewards.Add(typeof(T));
    }

    public void RemoveCloseReward<T>() where T : RewardBase
    {
        _closeRewards.Remove(typeof(T));
    }


    public Choice NewEventChoice()
    {
        var newChoice = new Choice(this);

        // Every Event Choice automatically gets a close event
        newChoice.AddReward<CloseEventReward>();

        return newChoice;
    }

    public Choice NewEventChoice(string choiceText)
    {
        var newChoice = new Choice(this);

        // Every Event Choice automatically gets a close event
        newChoice.AddReward<CloseEventReward>();

        newChoice.Text = choiceText;

        return newChoice;
    }

    public Choice AddContinueChoice(string text = "…")
    {
        var newChoice = new Choice(this);

        newChoice.AddReward<CloseEventReward>();
        newChoice.Text = text;

        AddChoice(newChoice);

        return newChoice;
    }

    public void AddChoice(Choice newChoice)
    {
        choices.Add(newChoice);
        Story.AddChoice(newChoice);
    }

    public abstract void StartEvent();

    public void CloseEvent()
    {
        foreach (var rewardType in _closeRewards)
        {
            var reward = EventHelper.CreateRewardByType(rewardType);
            reward.RunReward();
        }
    }
}
