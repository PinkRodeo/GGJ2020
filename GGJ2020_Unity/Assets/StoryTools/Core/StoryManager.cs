using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StoryEventDelegate(EventBase storyEvent);
public delegate void StoryChoiceDelegate(Choice storyChoice);

public class StoryManager : Singleton<StoryManager>
{
    public StoryEventDelegate OnEventStart;
    public StoryEventDelegate OnEventClose;
    
    public StoryChoiceDelegate OnChoiceAdded;
    public StoryChoiceDelegate OnChoiceRemoved;

    private EventBase currentEvent;
    private Queue<EventBase> eventQueue = new Queue<EventBase>();

    private List<Choice> currentChoices = new List<Choice>();

    public void AddEvent(EventBase storyEvent)
    {
        StoryLog.Log("Adding Event");

        if (currentEvent == null)
        {
            _SetCurrentEvent(storyEvent);
        }
        else
        {
            eventQueue.Enqueue(storyEvent);
        }
    }

    public void AddEvent<T>() where T : EventBase
    {
        var newEvent = EventHelper.CreateEventByType(typeof(T));
        AddEvent(newEvent);
    }

    public void CloseEvent()
    {
        StoryLog.Log("Closing Even");
        if (currentEvent != null)
        {
            var oldEvent = currentEvent;
            currentEvent = null;

            var oldChoices = currentChoices.ToArray();
            foreach (var choice in oldChoices)
            {
                RemoveChoice(choice);
            }

            currentChoices.Clear();
            if (OnEventClose != null)
                OnEventClose(oldEvent);
        }

        if (IsEventQueued())
        {
            _SetCurrentEvent(eventQueue.Dequeue());
        }
    }

    public bool IsEventAvailable()
    {
        return IsEventActive() || IsEventQueued();
    }

    public bool IsEventActive()
    {
        return currentEvent != null;
    }

    public bool IsEventQueued()
    {
        return eventQueue.Count > 0;
    }

    public void AddChoice(Choice newChoice)
    {
        if (currentChoices.Contains(newChoice))
        {
            Debug.LogError("Tried to add new choice when it already existed!");
            return;
        }
        currentChoices.Add(newChoice);
        if (OnChoiceAdded != null)
            OnChoiceAdded(newChoice);
    }

    /// <summary>
    /// Try to remove a choice
    /// </summary>
    /// <param name="choiceToRemove"></param>
    /// <returns>
    /// Was the choice succesfully removed.
    /// </returns>
    public bool RemoveChoice(Choice choiceToRemove)
    {
        bool was_removed = currentChoices.Remove(choiceToRemove);

        if (was_removed)
        {
            if (OnChoiceRemoved != null)
                OnChoiceRemoved(choiceToRemove);
        }

        return was_removed;
    }

    private void _SetCurrentEvent(EventBase newEvent)
    {
        currentEvent = newEvent;
        currentEvent.StartEvent();
        if (OnEventStart != null)
            OnEventStart(newEvent);
    }

    public void Reset()
    {
        while (currentEvent == null)
        {
            CloseEvent();
        }


    }

}
