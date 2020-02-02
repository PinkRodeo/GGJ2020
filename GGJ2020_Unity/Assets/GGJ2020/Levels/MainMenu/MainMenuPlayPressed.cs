using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(Button))]
public class MainMenuPlayPressed : MonoBehaviour
{
    Button button;
    [SerializeField]
    Image background;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        Image image = GetComponent<Image>();
        var text = GetComponentInChildren<TextMeshProUGUI>();
        button.onClick.AddListener(() =>
        {
            var imagetargetColor = image.color;
            imagetargetColor.a = 0;


            button.interactable = false;
            text.DOFade(0, 0.18f).SetEase(Ease.Linear);
            image.DOFade(0, 0.18f).SetEase(Ease.Linear); //(imagetargetColor, 0.15f).SetEase(Ease.OutFlash).Play();
            background.DOFade(0, 0.18f).SetEase(Ease.Linear);

            CameraEffects.StartFadeToBlack(() =>
            {
                Gamemode.LoadSceneBlocking(rooms.Game);

            }, DG.Tweening.Ease.InQuart, 1.2f
            );
        });
    }
}
