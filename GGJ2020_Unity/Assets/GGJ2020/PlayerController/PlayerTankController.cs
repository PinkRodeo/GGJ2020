﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTankController : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float movementSpeed = 5f;

    private Vector2 movementInput = Vector2.zero;

    private IInteractable currentInteractable;


    public void MovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (currentInteractable != null)
        {
            currentInteractable.OnInteract();
        }
    }



    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Gamemode.RegisterPlayer(this);
    }



    void Update()
    {
        if (currentInteractable != null)
        {
            currentInteractable.OnHover();
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = transform.forward * (movementInput.y * movementSpeed);
        rigidBody.MoveRotation(Quaternion.Euler(rigidBody.rotation.eulerAngles + new Vector3(0, movementInput.x * rotationSpeed, 0)));
    }


    void OnTriggerEnter(Collider collider)
    {
        IInteractable targetobj = collider.GetComponent<IInteractable>();
        if (targetobj != null)
        {
            if (targetobj.GetEnterCollider() == collider)
            {
                currentInteractable = targetobj;
                targetobj.OnEnter();
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        IInteractable targetobj = collider.GetComponent<IInteractable>();
        if (targetobj != null)
        {
            if (targetobj == currentInteractable)
            {
                if (targetobj.GetExitCollider() == collider)
                {
                    currentInteractable.OnExit();
                    currentInteractable = null;
                }

            }

        }
    }


}
