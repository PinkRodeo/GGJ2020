﻿using System.Collections;
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

                GameObject.DontDestroyOnLoad(cam);
            };
            return cam;

        }
    }

    static GameObject cam;

    //Only 1 cam tween at a time
    static Tween ActiveTween;

    public static void StartFadeToBlack(DG.Tweening.TweenCallback onComplete, Ease ease = Ease.InQuart, float duration = 1.5f)
    {
        var cam = CinemachineCam.GetComponent<CinemachineStoryboard>();

        if (cam == null)
        {
            Debug.LogError("Cannot StartFadeToBlack, CinemachineStoryboard component is missing.");
            return;
        }

        FinishTween();

        ActiveTween = DOTween.To(() => cam.m_Alpha, x => cam.m_Alpha = x, 1.5f, duration).OnComplete(onComplete).SetEase(Ease.InQuart);// cam.m_Alpha.
    }
    public static void StartFadeToGame(DG.Tweening.TweenCallback onComplete, Ease ease = Ease.OutQuart, float duration = 1.5f)
    {
        FinishTween();

        var cam = CinemachineCam.GetComponent<CinemachineStoryboard>();

        if (cam == null)
        {
            Debug.LogError("Cannot StartFadeToGame, CinemachineStoryboard component is missing.");
            return;
        }

        ActiveTween = DOTween.To(() => cam.m_Alpha, x => cam.m_Alpha = x, 0f, duration).OnComplete(onComplete).SetEase(Ease.OutQuart);
    }

    //Fade to black and get half way there a callback
    public static void StartFadeToBlackToGame(DG.Tweening.TweenCallback OnHalfway, Ease easeIn = Ease.InQuart, Ease EaseOut = Ease.InOutQuart, float duration = 1.5f)
    {
        FinishTween();

        var cam = CinemachineCam.GetComponent<CinemachineStoryboard>();

        StartFadeToBlack(() =>
        {
            OnHalfway.Invoke();
            StartFadeToGame(() => { }, EaseOut);
        }, easeIn);

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
