using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EventPanelComponent : MonoBehaviour
{
	public TextMeshProUGUI eventTitleText;
	public TextMeshProUGUI eventText;
	public Image ColorSkinImage;

	public ChoiceButtonComponent[] choiceButtons;
	public CanvasGroup eventPanelGroup;

	public EventBase currentEvent;

	public EventUIScriptableObject uiTypes;
	Vector2 originalScale;

	public void Start()
	{
		uiTypes = Gamemode.GetUiSettings();

		StoryManager.Instance.OnEventStart += OnEventStart;
		StoryManager.Instance.OnEventClose += OnEventClose;

		StoryManager.Instance.OnChoiceAdded += OnChoiceAdded;
		StoryManager.Instance.OnChoiceRemoved += OnChoiceRemoved;

		SetVisible(false);
		originalScale = eventText.transform.parent.GetComponent<RectTransform>().sizeDelta;
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

			foreach (var button in choiceButtons)
			{
				button.ClearChoice();
			}
		}
	}

	public void OnEventStart(EventBase storyEvent)
	{
		if (currentEvent != null)
		{
			OnEventClose(storyEvent);
		}

		if (storyEvent == null)
		{
			Debug.LogError("Story Event was not valid!");
			return;
		}

		//var colors = button.colors;
		//colors.normalColor = choice.ParentEvent.ConversationActor.Tint;
		//button.colors = colors;

		currentEvent = storyEvent;
		SetVisible(true);
		SetToEvent(storyEvent);
	}

	public void OnEventClose(EventBase storyEvent)
	{
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
		if (newEvent.IsClosing())
		{
			return;
		}

		var data = uiTypes.GetDataForCategory(newEvent.ConversationActor.ActorCategory);
		eventText.text = newEvent.Text;
		eventText.alignment = data.alignment;
		eventText.font = data.font;

		var eventBorderRect = eventText.transform.parent.GetComponent<RectTransform>();

		if (data.RightTextPanelOverride != 0)
		{
			var oldScale = eventBorderRect.sizeDelta;
			oldScale.x = data.RightTextPanelOverride;
			eventBorderRect.sizeDelta = oldScale;

		}
		else
		{
			eventBorderRect.sizeDelta = originalScale;
		}

		if (data.UseColorBorder)
		{
			ColorSkinImage.color = newEvent.ConversationActor.Tint;
			ColorSkinImage.gameObject.SetActive(true);
		}
		else
		{
			ColorSkinImage.gameObject.SetActive(false);
		}


		eventText.GetComponentInParent<Image>().sprite = data.TextBoxSprite;

		var EventActorName = newEvent.ConversationActor.Name;

		if (EventActorName != "")
		{
			eventTitleText.transform.parent.gameObject.SetActive(true);
			eventTitleText.text = "-" + newEvent.ConversationActor.Name;
			eventTitleText.font = data.font;
			eventTitleText.GetComponentInParent<Image>().sprite = data.TitleSprite;
		}
		else
		{ eventTitleText.transform.parent.gameObject.SetActive(false); }
	}
}