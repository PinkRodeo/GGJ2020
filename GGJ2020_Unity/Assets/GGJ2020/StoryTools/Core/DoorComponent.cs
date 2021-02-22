﻿using UnityEngine;
using DG.Tweening;

public enum E_DoorType
{
    DoorA,
    DoorB,
}

public class DoorComponent : MonoBehaviour
{
    public E_DoorType DoorType;
    private Vector3 _originalLocation;

    private MeshRenderer _meshRenderer;


    public Material _doorIndicatorMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        var sharedMaterials = _meshRenderer.sharedMaterials;
        _doorIndicatorMaterial = new Material(sharedMaterials[1]);
        sharedMaterials[1] = _doorIndicatorMaterial;
        _meshRenderer.sharedMaterials = sharedMaterials;

        _originalLocation = transform.localPosition;

        if (DoorType == E_DoorType.DoorA)
        {
            OnDoorStateChanged(StoryState.Instance.Door_A_State);
            StoryState.Instance.OnDoorAChanged += OnDoorStateChanged;
        }
        else
        {
            OnDoorStateChanged(StoryState.Instance.Door_B_State);
            StoryState.Instance.OnDoorBChanged += OnDoorStateChanged;
        }
    }

    private void OnDoorStateChanged(E_DoorState newDoorState)
    {
        // if (true)
        //     return;

        switch (newDoorState)
        {
            case E_DoorState.Locked:
                transform.DOLocalMove(_originalLocation, 0.8f, false);
                _doorIndicatorMaterial.DOColor(new Color(5.5816f, 3.79995f, 0.1008f), "Color_822c43bc6b72482a8a54bfa7a4945922", 0.2f);

                break;
            case E_DoorState.Unlocked:
                transform.DOLocalMove(_originalLocation, 0.8f, false);
                _doorIndicatorMaterial.DOColor(new Color(1.882959f, 5.648877f, 52.45385f), "Color_822c43bc6b72482a8a54bfa7a4945922", 0.4f);

                break;
            case E_DoorState.Open:
                transform.DOLocalMove(_originalLocation + new Vector3(0, 2.213f, 0), 1.2f, false).SetEase(Ease.InCubic);
                _doorIndicatorMaterial.DOColor(new Color(1.882959f, 5.648877f, 52.45385f), "Color_822c43bc6b72482a8a54bfa7a4945922", 0.4f);

                break;
            case E_DoorState.ShutHard:
                transform.DOLocalMove(_originalLocation, 0.35f, false).SetEase(Ease.OutBack);
                _doorIndicatorMaterial.DOColor(new Color(46.246f, 0.6544f, 0.6544f), "Color_822c43bc6b72482a8a54bfa7a4945922", 0.2f);

                break;
            default:
                break;
        }
    }
}