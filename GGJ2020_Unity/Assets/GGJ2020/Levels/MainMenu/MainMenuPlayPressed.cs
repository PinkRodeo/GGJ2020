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
            text.DOFade(0, .15f).SetEase(Ease.OutFlash);
            image.DOFade(0, 15f).SetEase(Ease.OutFlash); //(imagetargetColor, 0.15f).SetEase(Ease.OutFlash).Play();

            CameraEffects.StartFadeToBlackToGame(() =>
            {
                Gamemode.StartLoadingScene(rooms.Game);

            }, DG.Tweening.Ease.InQuart, Ease.OutQuart, .3f
            );
        });
    }
}
