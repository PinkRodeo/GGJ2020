using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBase
{
    protected static StoryManager Story = StoryManager.Instance;
    private string _text;
    private List<Choice> choices = new List<Choice>();

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

    public Choice NewEventChoice()
    {
        var newChoice = new Choice(this);

        // Every Event Choice automatically gets a close event
        newChoice.AddReward<CloseEventReward>();

        return newChoice;
    }

    public Choice AddContinueChoice()
    {
        var newChoice = new Choice(this);

        newChoice.AddReward<CloseEventReward>();
        newChoice.Text = "Continue";

        AddChoice(newChoice);

        return newChoice;
    }

    public void AddChoice(Choice newChoice)
    {
        choices.Add(newChoice);
        Story.AddChoice(newChoice);
    }

    public abstract void StartEvent();
}
