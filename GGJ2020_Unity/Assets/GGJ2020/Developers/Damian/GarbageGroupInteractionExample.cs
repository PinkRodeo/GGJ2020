using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageGroupInteractionExample : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		GarbageGroup.BindToFinish(GroupName.testGroup, () => { print("finished"); });
	}
}
