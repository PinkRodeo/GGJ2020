using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButtonComponent : MonoBehaviour
{
    public TextMeshProUGUI choiceText;

    public Choice currentChoice;

    public Button button;

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
        this.gameObject.SetActive(isVisible);

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
        currentChoice = null;
        SetVisible(false);
    }
}
