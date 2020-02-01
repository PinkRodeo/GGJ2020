using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnEnter();
    void OnExit();
    void OnPressed();
    void OnHover();
}

namespace Player
{
    [RequireComponent(typeof(Collider))]
    public class Interactable : MonoBehaviour, IInteractable
    {
        public void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }

        public void OnHover()
        {
            throw new System.NotImplementedException();
        }

        public void OnPressed()
        {
            throw new System.NotImplementedException();
        }
        void OnValidate()
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }
}
