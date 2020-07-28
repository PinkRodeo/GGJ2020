using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class GarbageItem : MonoBehaviour
{
	SphereCollider collider;
	GarbageGroup group;

	public GarbageGroup GetGroup() { return group; }
	void Awake()
	{
		collider = GetComponent<SphereCollider>();
		collider.isTrigger = true;

	}

	void Start()
	{
		group = transform.GetComponentInParent<GarbageGroup>();
		if (group == null)
		{
			Debug.LogError("Failed to find GarbageGroup for item", gameObject);
		}
		group.Register(this);
	}

	void Clean()
	{
		group.ItemCleaned(this);
	}

	void OnTriggerEnter(Collider collider)
	{
		var player = collider.GetComponent<PlayerTankController>();
		if (player != null)
		{
			print("cleaning");
			Clean();
		}
	}
}
