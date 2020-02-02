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

    private EventUIScriptableObject uiTypes;

    private StudioEventEmitter EmitterSelect;
    private StudioEventEmitter EmitterSubmit;
    private StudioEventEmitter EmitterAppear;



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
                return;
            currentChoice.Select();
        });
    }

    public void SetVisible(bool isVisible)
    {
        // TODO animate with tweens
        //this.gameObject.SetActive(isVisible);

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
        E_ActorCategory category = choice.ParentEvent.ConversationActor.ActorCategory;

        var data = uiTypes.GetDataForCategory(category);


        EmitterAppear.Play();

        currentChoice = choice;
        SetVisible(true);
        choiceText.text = choice.Text;

        choiceText.font = data.font;
        //choiceText.UpdateFontAsset();
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
        print("select");
        HoverEvent();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        print("submit");
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
