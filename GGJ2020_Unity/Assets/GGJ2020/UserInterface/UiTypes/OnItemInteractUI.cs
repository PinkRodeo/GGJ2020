using UnityEngine;
using DG.Tweening;

public class OnItemInteractUI : MonoBehaviour
{
    static OnItemInteractUI instance;
    public TMPro.TextMeshProUGUI text;

    public static void SetActive(bool enabled)
    {
        instance.Toggle(enabled);

    }

    void Toggle(bool enabled)
    {
        if (enabled)
        {
            text.DOFade(1f, 0.05f).SetEase(Ease.InCubic);
        }
        else
        {
            text.DOFade(0f, 0.5f).SetEase(Ease.OutSine);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        SetActive(false);
    }
}
