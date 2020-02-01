using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public static class CameraEffects
{
    static readonly string CinemachineCamName = "CinemachineFadeCams";
    static GameObject CinemachineCam
    {
        get
        {
            if (cam == null)
            {
                cam = GameObject.Find(CinemachineCamName);

                if (cam == null)
                    Debug.LogWarning($"Failed to find gameobject with name: {CinemachineCamName}");
            };
            return cam;

        }
    }

    static GameObject cam;

    //Only 1 cam tween at a time
    static Tween ActiveTween;

    public static void StartFadeToBlack(DG.Tweening.TweenCallback onComplete, Ease ease = Ease.InQuart, float duration = 1.5f)
    {
        Debug.Log(CinemachineCam);
        var cam = CinemachineCam.GetComponent<CinemachineStoryboard>();

        FinishTween();

        ActiveTween = DOTween.To(() => cam.m_Alpha, x => cam.m_Alpha = x, 1f, duration).OnComplete(onComplete).SetEase(Ease.InQuart);// cam.m_Alpha.
    }
    public static void StartFadeToGame(DG.Tweening.TweenCallback onComplete, Ease ease = Ease.OutQuart, float duration = 1.5f)
    {
        FinishTween();

        var cam = CinemachineCam.GetComponent<CinemachineStoryboard>();

        ActiveTween = DOTween.To(() => cam.m_Alpha, x => cam.m_Alpha = x, 0f, duration).OnComplete(onComplete).SetEase(Ease.OutQuart);
    }

    //Fade to black and get half way there a callback
    public static void StartFadeToBlackToGame(DG.Tweening.TweenCallback OnHalfway, Ease ease, float duration = 1.5f)
    {
        FinishTween();

        var cam = CinemachineCam.GetComponent<CinemachineStoryboard>();

        StartFadeToBlack(() =>
        {
            OnHalfway.Invoke();
            StartFadeToGame(() => { });
        });

    }

    static void FinishTween()
    {
        if (ActiveTween != null)
        {
            ActiveTween.Kill(true);
        }
    }

    static bool IsATweenActive()
    {
        return ActiveTween != null;
    }
}
