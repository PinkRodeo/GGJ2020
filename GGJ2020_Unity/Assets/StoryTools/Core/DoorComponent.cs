using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	// Start is called before the first frame update
	void Start()
	{
		_meshRenderer = GetComponent<MeshRenderer>();
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
		switch (newDoorState)
		{
			case E_DoorState.Locked:
				transform.DOLocalMove(_originalLocation, 0.8f, false);
				_meshRenderer.materials[1].DOColor(new Color(5.5816f, 3.79995f, 0.1008f), "EmissionCol", 0.2f);

				break;
			case E_DoorState.Unlocked:
				transform.DOLocalMove(_originalLocation, 0.8f, false);
				_meshRenderer.materials[1].DOColor(new Color(1.882959f, 5.648877f, 52.45385f), "EmissionCol", 0.4f);

				break;
			case E_DoorState.Open:
				transform.DOLocalMove(_originalLocation + new Vector3(0, 2.213f, 0), 1.2f, false).SetEase(Ease.InCubic);
				_meshRenderer.materials[1].DOColor(new Color(1.882959f, 5.648877f, 52.45385f), "EmissionCol", 0.4f);

				break;
			case E_DoorState.ShutHard:
				transform.DOLocalMove(_originalLocation, 0.35f, false).SetEase(Ease.OutBack);
				_meshRenderer.materials[1].DOColor(new Color(46.246f, 0.6544f, 0.6544f), "EmissionCol", 0.2f);

				break;
			default:
				break;
		}
	}
}