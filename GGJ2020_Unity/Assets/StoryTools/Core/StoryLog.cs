using UnityEngine;

public static class StoryLog
{
	public static void Log(object message)
	{
		Debug.Log("StoryLog: " + message.ToString());
	}
}
