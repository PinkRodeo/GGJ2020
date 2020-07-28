using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewardBase
{
	protected static StoryManager Story = StoryManager.Instance;

	public abstract void RunReward();
}
