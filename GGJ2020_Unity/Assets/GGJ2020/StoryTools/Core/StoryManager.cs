using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public delegate void StoryEventDelegate(Event storyEvent);
public delegate void StoryChoiceDelegate(Choice storyChoice);

public class StoryManager : Singleton<StoryManager>
{
    public StoryEventDelegate OnEventStart;
    public StoryEventDelegate OnEventClose;

    public StoryChoiceDelegate OnChoiceAdded;
    public StoryChoiceDelegate OnChoiceRemoved;

    private Event currentEvent;
    private Queue<Event> eventQueue = new Queue<Event>();

    private List<Choice> currentChoices = new List<Choice>();

    public void AddNextEvent(Event storyEvent)
    {
        if (currentEvent == null)
        {
            _SetCurrentEvent(storyEvent);
        }
        else
        {
            eventQueue.Enqueue(storyEvent);
        }
    }

    public void AddNextEvent<T>() where T : Event
    {
        var newEvent = EventHelper.CreateEventByType(typeof(T));
        AddNextEvent(newEvent);
    }

    public void CloseCurrentEvent()
    {
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
            oldEvent.CloseEvent();

            if (OnEventClose != null)
                OnEventClose(oldEvent);

            oldEvent = null;
        }
        else
        {
            Debug.Log("Panic?");
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

    private void _SetCurrentEvent(Event newEvent)
    {
        if (newEvent == null)
        {
            Debug.LogError("NewEvent needs to be valid");
            return;
        }
        currentEvent = newEvent;
        currentEvent.PlayEvent();

        if (currentEvent == null)
        {
            //Debug.Log("Event disposed of itself and didn't spawn follow ups.");
            return;
        }

        if (currentEvent.EventChoices == null)
        {
            Debug.Log("Event didn't have valid choices: " + newEvent.ToString());
            currentEvent.EventChoices = new List<Choice>();
        }
        else
        {
            foreach (var choice in currentEvent.EventChoices)
            {
                if (choice.DisplayOnEventStart == true)
                {
                    currentEvent.DisplayChoice(choice);
                }
            }

            currentEvent.EventChoices.Clear();
        }

        if (currentEvent.Text == "")
        {
            Debug.LogError("Event didn't get Text specified: " + newEvent.ToString());
        }
        var actor = newEvent.EventActor;
        if (actor == null)
        {
            Debug.LogError("Event doesn't define a ConversationActor " + newEvent.ToString());
        }

        if (OnEventStart != null)
            OnEventStart(newEvent);
    }

    public void GoToEndScreen()
    {
        CameraEffects.StartFadeToBlack(() =>
        {
            DOTween.KillAll(false);
            Reset();
            StoryState.Instance.Reset();
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);

        });
    }

    public void Reset()
    {
        while (currentEvent != null)
        {
            CloseCurrentEvent();
        }

    }

}
