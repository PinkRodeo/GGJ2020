using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public string eventToTrigger;

    public MeshRenderer[] MeshesToHighlight;

    private List<Material> _materials = new List<Material>();

    public bool bInteractable = false;

    // Start is called before the first frame update
    void Start()
    {

        var materials = new List<Material>();
        foreach (var meshRenderer in MeshesToHighlight)
        {
            meshRenderer.GetMaterials(materials);

            foreach (var material in materials)
            {
                _materials.Add(material);
            }
        }

        SetHighlightAmount(0.1f);
    }

    void SetHighlightAmount(float amount)
    {
        for (int i = 0; i < _materials.Count; i++)
        {
            _materials[i].SetFloat("Vector1_5B25C606", amount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bInteractable = Input.GetKey(KeyCode.T) && !StoryManager.Instance.IsEventActive();

        if (bInteractable)
        {
            SetHighlightAmount(1f);
        }
        else
        {
            SetHighlightAmount(0f);
        }


        if (Input.GetKeyUp(KeyCode.Y) && bInteractable)
        {
            var newEvent = EventHelper.CreateEventByString(eventToTrigger);
            if (newEvent == null)
            {
                Debug.LogError("Couldn't find event: " + eventToTrigger);
                return;
            }
            StoryManager.Instance.AddEvent(newEvent);
        }
    }


}
