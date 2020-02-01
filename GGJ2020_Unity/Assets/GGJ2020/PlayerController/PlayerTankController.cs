using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTankController : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float movementSpeed = 5f;



    private Vector2 movementInput = Vector2.zero;

    private float currentMovementSpeed = 0f;


    private float rotationChangeSpeed = 0f;
    private float currentRotationSpeed = 0f;

    private IInteractable currentInteractable;
    private StudioEventEmitter emitterOutline;
    private StudioEventEmitter emitterInteract;
    private StudioEventEmitter emitterDriving;

    public void MovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (currentInteractable != null && IsMovementInputAllowed())
        {
            emitterInteract.Play();
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
        SetupAudioEmitters();
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
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            return;
        }

        if (Mathf.Abs(movementInput.x) > 0f)
        {
            currentRotationSpeed = Mathf.SmoothDamp(currentRotationSpeed, rotationSpeed * movementInput.x, ref rotationChangeSpeed, 0.2f, 20f, Time.fixedDeltaTime);
        }
        else
        {
            currentRotationSpeed = Mathf.SmoothDamp(currentRotationSpeed, rotationSpeed * movementInput.x, ref rotationChangeSpeed, 0.15f, 50f, Time.fixedDeltaTime);
        }

        if (Mathf.Abs(movementInput.y) > 0f)
        {
            currentMovementSpeed = Mathf.Lerp(currentMovementSpeed, movementInput.y * movementSpeed, 0.17f);
        }
        else
        {
            currentMovementSpeed = Mathf.Lerp(currentMovementSpeed, movementInput.y * movementSpeed, 0.28f);
        }

        rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, transform.forward * currentMovementSpeed, 0.14f);

        var rotationModifier = Mathf.Abs(currentMovementSpeed);

        rigidBody.MoveRotation(Quaternion.Euler(rigidBody.rotation.eulerAngles + new Vector3(0, Mathf.Lerp(currentRotationSpeed, currentRotationSpeed * 0.7f, rotationModifier), 0)));

        var speed = rigidBody.velocity.magnitude == 0 ? rigidBody.angularVelocity.magnitude : rigidBody.velocity.magnitude;
        if (speed < .1f)
        {
            emitterDriving.Stop();
        }
        else
        {
            emitterDriving.SetParameter("RobotSpeed", speed -.1f);
            if (!emitterDriving.IsPlaying())
                emitterDriving.Play();
        }

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
        emitterOutline.Play();
        interactable.OnEnter();
    }

    private void StopInteracting()
    {
        currentInteractable.OnExit();
        currentInteractable = null;
    }

    void SetupAudioEmitters()
    {
        emitterOutline = gameObject.AddComponent<StudioEventEmitter>();
        emitterInteract = gameObject.AddComponent<StudioEventEmitter>();
        emitterDriving = gameObject.AddComponent<StudioEventEmitter>();

        emitterOutline.Event = "event:/Interact_OutlineAppears";
        emitterInteract.Event = "event:/Interact_InteractConfirmed";
        emitterDriving.Event = "event:/RobotMovement";

    }

}
