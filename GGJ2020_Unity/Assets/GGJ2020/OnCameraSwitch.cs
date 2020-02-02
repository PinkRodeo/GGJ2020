using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class OnCameraSwitch : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    StudioEventEmitter emitter;
    [SerializeField]
    int room;

    void Awake()
    {
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

    private bool _HasSet = false;

    // Start is called before the first frame update
    void Start()
    {
        cam.m_Transitions.m_OnCameraLive.AddListener(
            (a, b) =>
            {
                if (!_HasSet)
                {
                    _HasSet = true;
                    emitter.SetParameter("Room", room);
                }
            });
    }

}
