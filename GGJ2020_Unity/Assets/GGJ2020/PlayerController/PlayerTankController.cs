using System.Collections;
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
        if (currentInteractable != null && IsMovementInputAllowed())
        {
            currentInteractable.OnInteract();
        }
    }

    public bool IsMovementInputAllowed()
    {
        return !StoryManager.Instance.IsEventActive();
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
            if (IsMovementInputAllowed())
            {
                currentInteractable.OnHover();
            }
            else
            {
                StopInteracting();
            }
        }
    }

    void FixedUpdate()
    {
        if (!IsMovementInputAllowed())
        {
            return;
        }

        rigidBody.velocity = transform.forward * (movementInput.y * movementSpeed);
        rigidBody.MoveRotation(Quaternion.Euler(rigidBody.rotation.eulerAngles + new Vector3(0, movementInput.x * rotationSpeed, 0)));
    }

    void OnTriggerEnter(Collider collider)
    {
        IInteractable targetObj = collider.GetComponent<IInteractable>();
        if (targetObj != null)
        {
            if (targetObj.GetEnterCollider() == collider)
            {
                StartInteracting(targetObj);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        IInteractable targetObj = collider.GetComponent<IInteractable>();
        if (targetObj != null)
        {
            if (targetObj == currentInteractable)
            {
                if (targetObj.GetExitCollider() == collider)
                {
                    StopInteracting();
                }
            }

        }
    }

    private void StartInteracting(IInteractable interactable)
    {
        if (currentInteractable != null)
        {
            StopInteracting();
        }

        currentInteractable = interactable;
        interactable.OnEnter();
    }

    private void StopInteracting()
    {
        currentInteractable.OnExit();
        currentInteractable = null;
    }


}
