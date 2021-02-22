using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FMODUnity;

public enum E_InteractType
{
    OnInteract,
    OnOverlap,
}

public interface IInteractable
{
    void OnEnter();
    void OnExit();
    void OnInteract();
    void OnHover();

    bool CanInteractWith();

    Collider GetExitCollider();
    Collider GetEnterCollider();

    E_InteractType GetInteractType();
}

namespace Player
{
    using UnityEngine;

    [RequireComponent(typeof(SphereCollider), typeof(StudioEventEmitter))]
    public class Interactable : MonoBehaviour, IInteractable
    {

        public E_InteractType _interactType = E_InteractType.OnInteract;
        public E_ThrowawayType throwAwayType = E_ThrowawayType.None;

        List<SphereCollider> Colliders = new List<SphereCollider>();

        [HideInInspector]
        public string eventToTrigger;

        public MeshRenderer[] MeshesToHighlight;

        private List<Material> _materialsToHighlight = new List<Material>();

        void Awake()
        {
            foreach (var meshRenderer in MeshesToHighlight)
            {
                var sharedMaterials = meshRenderer.sharedMaterials;
                bool changedOneMaterial = false;

                for (int i = 0; i < sharedMaterials.Length; i++)
                {
                    var material = sharedMaterials[i];

                    if (material.HasProperty("HighlightAmount"))
                    {
                        changedOneMaterial = true;
                        var materialInstance = new Material(material);
                        _materialsToHighlight.Add(materialInstance);
                        sharedMaterials[i] = materialInstance;
                    }
                }

                if (changedOneMaterial)
                {
                    meshRenderer.sharedMaterials = sharedMaterials;
                }
            }

            if (_interactType == E_InteractType.OnInteract && _materialsToHighlight.Count < 1)
            {
                Debug.LogWarning("Made object interactable: " + gameObject.ToString() + ", but none of its MeshesToHighlight have a highlightable material");
            }

            SetHighlightAmount(0.0f);

            SetupColliders();

            var state = StoryState.Instance;

            switch (throwAwayType)
            {
                case E_ThrowawayType.None:
                    // Nothing
                    break;
                case E_ThrowawayType.Capsules_A:
                    state.OnChanged_Capsules_A += OnThrowayTypeChanged;
                    OnThrowayTypeChanged(state.State_Capsules_A);
                    break;
                case E_ThrowawayType.Headset:
                    state.OnChanged_Headset += OnThrowayTypeChanged;
                    OnThrowayTypeChanged(state.State_Headset);
                    break;
                case E_ThrowawayType.Phone_A_Scott:
                    state.OnChanged_Phone_A_Scott += OnThrowayTypeChanged;
                    OnThrowayTypeChanged(state.State_Phone_A_Scott);
                    break;
                case E_ThrowawayType.Capsules_B:
                    state.OnChanged_Capsules_B += OnThrowayTypeChanged;
                    OnThrowayTypeChanged(state.State_Capsules_B);
                    break;
                case E_ThrowawayType.Vape:
                    state.OnChanged_Vape += OnThrowayTypeChanged;
                    OnThrowayTypeChanged(state.State_Vape);
                    break;
                case E_ThrowawayType.Phone_B_Jen:
                    state.OnChanged_Phone_B_Jen += OnThrowayTypeChanged;
                    OnThrowayTypeChanged(state.State_Phone_B_Jen);
                    break;
                case E_ThrowawayType.Shoes:
                    state.OnChanged_Shoes += OnThrowayTypeChanged;
                    OnThrowayTypeChanged(state.State_Shoes);
                    break;
                default:
                    Debug.LogError("Unhandled throwaway type: " + throwAwayType.ToString());
                    break;
            }
        }

        private E_ThrowawayState _currentThrowawayState = E_ThrowawayState.OnFloor;

        private void OnThrowayTypeChanged(E_ThrowawayState newThrowawayState)
        {
            _currentThrowawayState = newThrowawayState;

            switch (newThrowawayState)
            {
                case E_ThrowawayState.OnFloor:
                    foreach (var meshRenderer in MeshesToHighlight)
                    {
                        meshRenderer.gameObject.SetActive(true);
                    }
                    _IsInteractable = true;
                    break;
                case E_ThrowawayState.PickedUp:
                    foreach (var meshRenderer in MeshesToHighlight)
                    {
                        meshRenderer.gameObject.SetActive(false);
                    }
                    _IsInteractable = false;
                    break;
                case E_ThrowawayState.ThrownInHomeStation:
                    foreach (var meshRenderer in MeshesToHighlight)
                    {
                        meshRenderer.gameObject.SetActive(false);
                    }
                    _IsInteractable = false;
                    break;
                default:
                    break;
            }
        }

        void SetHighlightAmount(float amount)
        {
            for (int i = 0; i < _materialsToHighlight.Count; i++)
            {
                _materialsToHighlight[i].DOFloat(amount, "HighlightAmount", 0.3f);
            }
        }
        public E_InteractType GetInteractType()
        {
            return _interactType;
        }

        void SetupColliders()
        {
            GetComponent<Collider>().isTrigger = true;
            var ComponentColliders = GetComponents<SphereCollider>();
            Colliders.Clear();

            var TriggerComponents = new List<SphereCollider>();

            foreach (var item in ComponentColliders)
            {
                if (item.isTrigger)
                {
                    TriggerComponents.Add(item);
                }
            }

            ComponentColliders = TriggerComponents.ToArray();

            if (ComponentColliders.Length < 2)
            {
                for (int i = 0; i < (2 - ComponentColliders.Length); i++)
                {
                    var newCollider = gameObject.AddComponent<SphereCollider>();
                    newCollider.isTrigger = true;
                    Debug.LogWarning("Didn't add the correct components!!!");
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

                for (int ElementsLeft = currentElement - 1; ElementsLeft >= 0; ElementsLeft--)
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

        private bool _IsInteractable = true;

        public bool CanInteractWith()
        {
            return _IsInteractable && _currentThrowawayState == E_ThrowawayState.OnFloor;
        }

        public void OnEnter()
        {
            SetHighlightAmount(1f);

            if (_interactType == E_InteractType.OnOverlap)
            {
                RunEvent();
            }
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
            if (_interactType == E_InteractType.OnInteract)
            {
                RunEvent();
            }
        }

        private void RunEvent()
        {
            if (!CanInteractWith())
                return;

            var newEvent = EventHelper.CreateEventByString(eventToTrigger);
            if (newEvent == null)
            {
                Debug.LogError("Couldn't find event: " + eventToTrigger);
                return;
            }
            StoryManager.Instance.AddNextEvent(newEvent);
        }
    }
}
