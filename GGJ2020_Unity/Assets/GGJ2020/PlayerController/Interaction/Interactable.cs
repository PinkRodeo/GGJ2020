using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnEnter();
    void OnExit();
    void OnInteract();
    void OnHover();


    Collider GetExitCollider();
    Collider GetEnterCollider();
}

namespace Player
{
    using UnityEngine;

    [RequireComponent(typeof(SphereCollider))]
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        List<SphereCollider> Colliders = new List<SphereCollider>();

        [HideInInspector]
        public string eventToTrigger;

        public MeshRenderer[] MeshesToHighlight;

        private List<Material> _materials = new List<Material>();

        void Awake()
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

            SetHighlightAmount(0.0f);

            SetupColliders();
        }

        void SetHighlightAmount(float amount)
        {
            for (int i = 0; i < _materials.Count; i++)
            {
                _materials[i].SetFloat("Vector1_5B25C606", amount);
            }
        }

        void SetupColliders()
        {
            GetComponent<Collider>().isTrigger = true;
            SphereCollider[] ComponentColliders = GetComponents<SphereCollider>();
            Colliders.Clear();

            foreach (var item in ComponentColliders)
            {
                item.isTrigger = true;
            }

            if (ComponentColliders.Length < 2)
            {
                for (int i = 0; i < (2- ComponentColliders.Length); i++)
                {
                    gameObject.AddComponent<SphereCollider>();
                }
            }

            for (int currentElement = 0; currentElement < ComponentColliders.Length; currentElement++)
            {
                int FirstpossibleIndex = -1;

                var col = ComponentColliders[currentElement];

                float CurrentSize = col.bounds.size.magnitude;
                if (currentElement == 0)
                {
                    if (Colliders.Contains(col))
                    {
                        Colliders.Remove(col);
                    }

                    Colliders.Add(col);
                }

                for (int ElementsLeft = currentElement -1; ElementsLeft >= 0; ElementsLeft--)
                {
                    float leftSize = ComponentColliders[ElementsLeft].bounds.size.magnitude;



                    if (leftSize > CurrentSize)
                    {
                        if (FirstpossibleIndex < ElementsLeft)
                            FirstpossibleIndex = ElementsLeft;
                    }
                }

                if (FirstpossibleIndex == -1)
                {
                    if (Colliders.Contains(col))
                    {
                        Colliders.Remove(col);
                    }
                    Colliders.Add(col);
                }
                else
                {
                    if (Colliders.Contains(col))
                    {
                        Colliders.Remove(col);
                    }

                    Colliders.Insert(FirstpossibleIndex, col);

                }

            }

        }



        //interface implementation

        public Collider GetExitCollider()
        {
            return Colliders[Colliders.Count - 1];
        }

        public Collider GetEnterCollider()
        {
            return Colliders[0];
        }

        public void OnEnter()
        {
            SetHighlightAmount(1f);
        }

        public void OnExit()
        {
            SetHighlightAmount(0f);
        }

        public void OnHover()
        {
            //     print("Hovering");
        }

        public void OnInteract()
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
