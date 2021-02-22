using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class OnCameraSwitch : MonoBehaviour
{
    public CameraText cameraTextUI;
    CinemachineVirtualCamera cam;
    StudioEventEmitter emitter;
    [SerializeField]
    int roomId;

    [SerializeField]
    private string cameraText;

    private bool _HasTriggeredAudioChange = false;

    void Awake()
    {
        if (cameraText == null)
        {
            Debug.LogError("Missing reference to camera text UI");
        }

        cam = GetComponent<CinemachineVirtualCamera>();
        emitter = transform.parent.gameObject.GetComponent<StudioEventEmitter>();
        if (emitter == null)
        {
            emitter = transform.parent.gameObject.AddComponent<StudioEventEmitter>();
        }
        emitter.Event = FModStrings.Music;

        if (!emitter.IsPlaying())
            emitter.Play();

    }


    // Start is called before the first frame update
    void Start()
    {
        cam.m_Transitions.m_OnCameraLive.AddListener(
            (a, b) =>
            {
                cameraTextUI.SetLabel(cameraText);

                if (!_HasTriggeredAudioChange)
                {
                    _HasTriggeredAudioChange = true;
                    emitter.SetParameter("Room", roomId);
                }
            });
    }

}
