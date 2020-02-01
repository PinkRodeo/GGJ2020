using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoiceButtonComponent : MonoBehaviour
{
    public TextMeshProUGUI choiceText;

    public Choice currentChoice;

    public Button button;

    public CanvasGroup choiceButtonGroup;

    public void Awake()
    {
        SetVisible(false);

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
        currentChoice = choice;
        SetVisible(true);
        choiceText.text = choice.Text;
    }

    public void ClearChoice()
    {
        SetVisible(false);
        currentChoice = null;
    }
}
