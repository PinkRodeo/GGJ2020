using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public struct SMeshStruct
{
	public Mesh mesh;
	public MeshRenderer meshRenderer;

	public SMeshStruct(Mesh _mesh, MeshRenderer _meshRenderer)
	{
		mesh = _mesh;
		meshRenderer = _meshRenderer;
	}
}

[CustomEditor(typeof(MeshFixer))]
public class NewBehaviourScript : Editor
{
	private int _choiceIndex = 0;
	private string[] _choices = new[] { "non", "run" };

	void OnEnable()
	{

	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		_choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices);


		if (_choiceIndex == 1)
		{
			var interactable = target as MeshFixer;

			var objectsWithMaterial = new Dictionary<Mesh, SMeshStruct>();

			var meshRenderers = FindObjectsOfType(typeof(MeshRenderer));

			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				bool AllCorrect = true;
				foreach (var material in meshRenderer.sharedMaterials)
				{
					if (material == null)
					{
						AllCorrect = false;
					}
				}

				if (AllCorrect)
				{
					var mesh = meshRenderer.GetComponent<MeshFilter>().sharedMesh;

					if (!objectsWithMaterial.ContainsKey(mesh))
					{
						objectsWithMaterial.Add(mesh, new SMeshStruct(mesh, meshRenderer));
					}
				}
			}

			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				bool AllCorrect = true;
				foreach (var material in meshRenderer.sharedMaterials)
				{
					if (material == null)
					{
						AllCorrect = false;
					}
				}

				if (!AllCorrect)
				{
					var mesh = meshRenderer.GetComponent<MeshFilter>().sharedMesh;

					SMeshStruct correct = new SMeshStruct();

					if (objectsWithMaterial.TryGetValue(mesh, out correct))
					{
						var correctMaterials = correct.meshRenderer.sharedMaterials;

						meshRenderer.sharedMaterials = correctMaterials;
						EditorUtility.SetDirty(meshRenderer.gameObject);
						EditorUtility.SetDirty(meshRenderer);
					}
				}
			}

			_choiceIndex = 0;
		}

		EditorUtility.SetDirty(target);
	}
}