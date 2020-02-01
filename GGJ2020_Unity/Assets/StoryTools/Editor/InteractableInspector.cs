using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Interactable))]
public class InteractableInspector : Editor
{
    string[] _choices = new[] { "foo", "foobar" };
    int _choiceIndex = 0;

    void OnEnable()
    {
        _choices = EventHelper.GetAllEventStrings();
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices);

        var interactable = target as Interactable;

        interactable.eventToTrigger = _choices[_choiceIndex];

        EditorUtility.SetDirty(target);
    }

}
