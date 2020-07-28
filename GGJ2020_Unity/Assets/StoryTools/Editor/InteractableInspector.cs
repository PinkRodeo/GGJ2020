using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player.Interactable))]
public class InteractableInspector : Editor
{
	string[] _choices = new[] { "foo", "foobar" };
	int _choiceIndex = 0;

	void OnEnable()
	{
		_choices = EventHelper.GetAllEventStrings();

		var interactable = target as Player.Interactable;
		var currentEvent = interactable.eventToTrigger;

		_choiceIndex = -1;

		for (int i = 0; i < _choices.Length; i++)
		{
			if (_choices[i] == currentEvent)
			{
				_choiceIndex = i;
			}
		}

		if (_choiceIndex == -1)
		{
			if (currentEvent == "")
			{
				// This just means no event was set yet.
				_choiceIndex = 0;
			}
			else
			{
				Debug.LogError("Couldn't find event: " + currentEvent);
				_choiceIndex = 0;
			}
		}
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		_choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices);

		var interactable = target as Player.Interactable;

		interactable.eventToTrigger = _choices[_choiceIndex];

		EditorUtility.SetDirty(target);
	}

}
