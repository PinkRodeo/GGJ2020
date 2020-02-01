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

        void Awake()
        {
            OnValidate();
        }

        void OnValidate()
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

                float CurrentSize = ComponentColliders[currentElement].bounds.size.magnitude;
                if (currentElement == 0)
                {
                    Colliders.Add(ComponentColliders[currentElement]);
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
                    Colliders.Add(ComponentColliders[currentElement]);
                }
                else
                    Colliders.Insert(FirstpossibleIndex, ComponentColliders[currentElement]);

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

            print("OnEnter");
        }

        public void OnExit()
        {
            print("OnExit");
        }

        public void OnHover()
        {
            //     print("Hovering");
        }

        public void OnInteract()
        {
            print("pressed");
        }
    }
}
