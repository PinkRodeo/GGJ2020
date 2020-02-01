using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class EventPanelComponent : MonoBehaviour
{
    public TextMeshProUGUI eventText;

    public ChoiceButtonComponent[] choiceButtons;
    public CanvasGroup eventPanelGroup;

    public EventBase currentEvent;

    public void Start()
    {
        StoryManager.Instance.OnEventStart += OnEventStart;
        StoryManager.Instance.OnEventClose += OnEventClose;

        StoryManager.Instance.OnChoiceAdded += OnChoiceAdded;
        StoryManager.Instance.OnChoiceRemoved += OnChoiceRemoved;

        SetVisible(false);

    }

    public void SetVisible(bool isVisible)
    {
        // TODO animate with tweens
        //this.gameObject.SetActive(isVisible);

        if (isVisible)
        {
            eventPanelGroup.DOFade(1.0f, 0.3f).SetEase(Ease.OutSine);
        }
        else
        {
            eventPanelGroup.DOFade(0.0f, 0.1f).SetEase(Ease.InSine);
        }
    }

    public void OnEventStart(EventBase storyEvent)
    {
        if (currentEvent != null)
        {
            Debug.LogError("Event was still active in the UI, not supposed to happen");
        }
        currentEvent = storyEvent;
        SetVisible(true);
        SetToEvent(storyEvent);
    }

    public void OnEventClose(EventBase storyEvent)
    {
        if (storyEvent != currentEvent)
        {
            Debug.LogError("Event closed wasn't the one active ");
            return;
        }

        currentEvent = null;

        if (!StoryManager.Instance.IsEventAvailable())
        {
            SetVisible(false);
        }
    }

    public void OnChoiceAdded(Choice choice)
    {
        foreach (var choiceButton in choiceButtons)
        {
            if (choiceButton.currentChoice != null)
                continue;

            choiceButton.SetToChoice(choice);
            return;
        }

        Debug.LogError("Couldn't find free choice");
    }

    public void OnChoiceRemoved(Choice choice)
    {
        foreach (var choiceButton in choiceButtons)
        {
            if (choiceButton.currentChoice != choice)
                continue;

            choiceButton.ClearChoice();
            return;
        }

        Debug.LogError("Couldn't remove choice from any button, it wasn't active ;(");
    }

    public void SetToEvent(EventBase newEvent)
    {
        eventText.text = newEvent.Text;
    }
}
