using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using FMODUnity;
using UnityEngine.EventSystems;

public class ChoiceButtonComponent : MonoBehaviour, IPointerEnterHandler, ISelectHandler, ISubmitHandler, IPointerDownHandler
{
	public TextMeshProUGUI choiceText;

	public Choice currentChoice;

	public Button button;

	public CanvasGroup choiceButtonGroup;

	private StudioEventEmitter EmitterSelect;
	private StudioEventEmitter EmitterSubmit;
	private StudioEventEmitter EmitterAppear;
	private EventUIScriptableObject uiTypes;

	public void Awake()
	{
		SetVisible(false);

		uiTypes = Gamemode.GetUiSettings();

		EmitterSelect = gameObject.AddComponent<StudioEventEmitter>();
		EmitterSelect.Event = FModStrings.ChoiceHover;
		EmitterSubmit = gameObject.AddComponent<StudioEventEmitter>();
		EmitterSubmit.Event = FModStrings.ChoiceClick;
		EmitterAppear = gameObject.AddComponent<StudioEventEmitter>();
		EmitterAppear.Event = FModStrings.ListAppear;

		button.onClick.AddListener(delegate
		{
			if (currentChoice == null)
			{
				Debug.LogError("Button shouldn't have beenn interactable");
				return;
			}
			currentChoice.Select();
		});

		uiTypes = Gamemode.GetUiSettings();
	}

	public void SetVisible(bool isVisible)
	{
		if (isVisible)
		{
			choiceButtonGroup.DOFade(1.0f, 0.5f).SetEase(Ease.OutSine);
		}
		else
		{
			choiceButtonGroup.DOFade(0.0f, 0.1f).SetEase(Ease.InSine);
		}

		button.interactable = isVisible;
	}

	public void SetToChoice(Choice choice)
	{
		//TODO fix this sound
		E_ActorCategory category = choice.ParentEvent.EventActor.ActorCategory;

		var data = uiTypes.GetDataForCategory(category);


		EmitterAppear.Play();
		if (data == null)
		{
			Debug.LogError($"No UI data found for {choice.ParentEvent.EventActor.ActorCategory}");
			return;
		}

		currentChoice = choice;
		SetVisible(true);
		choiceText.text = choice.Text;

		choiceText.font = data.font;
		//choiceText.UpdateFontAsset();
		choiceText.alignment = TextAlignmentOptions.Left;
		choiceText.font = data.font;

		var parrentButton = choiceText.GetComponentInParent<Button>();
		var parrentImage = choiceText.GetComponentInParent<Image>();

		var spriteState = parrentButton.spriteState;
		spriteState.pressedSprite = data.PressedSprite;
		spriteState.selectedSprite = data.SelectedSprite;
		spriteState.highlightedSprite = data.SelectedSprite;
		parrentButton.spriteState = spriteState;
		parrentImage.sprite = data.DefaultSprite;
	}

	public void ClearChoice()
	{
		SetVisible(false);
		currentChoice = null;
	}


	#region Audio Handlers
	public void OnPointerDown(PointerEventData eventData)
	{
		if (button.interactable)
			SubmitEvent();

	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (button.interactable)
			HoverEvent();
	}

	public void OnSelect(BaseEventData eventData)
	{
		HoverEvent();
	}

	public void OnSubmit(BaseEventData eventData)
	{
		SubmitEvent();
	}


	void HoverEvent()
	{
		// Emitter.Event = FModStrings.ChoiceClick;

		EmitterSelect.Play();
	}
	void SubmitEvent()
	{

		EmitterSubmit.Play();
	}
	#endregion

}
