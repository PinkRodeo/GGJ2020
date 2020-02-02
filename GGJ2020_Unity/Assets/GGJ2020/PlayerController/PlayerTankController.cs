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

    private float previousAudioSpeed = 0f;
    private IInteractable currentInteractable;
    private StudioEventEmitter emitterOutline;
    private StudioEventEmitter emitterInteract;
    private StudioEventEmitter emitterDriving;

    private bool _wasFullyStopped = true;

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
                //SHOULD FIX Interaction issue
            //    StopInteracting();
            }
        }
    }

    void FixedUpdate()
    {
        if (!IsMovementInputAllowed())
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;

            emitterDriving.SetParameter("RobotSpeed", .00f);
            emitterDriving.Stop();

            _wasFullyStopped = true;

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

        var nextSpeed = Mathf.Clamp(movementInput.magnitude, 0f, 1f);
        if (nextSpeed > previousAudioSpeed)
        {
            nextSpeed = Mathf.MoveTowards(previousAudioSpeed, nextSpeed, 0.5f * Time.fixedDeltaTime);
        }

        var speed = Mathf.Max(nextSpeed, previousAudioSpeed);
        if (_wasFullyStopped)
        {
            if (movementInput.magnitude > 0.2f)
            {
                _wasFullyStopped = false;
            }
            else
            {
                return;
            }
        }
        if (speed < .05f)
        {
            emitterDriving.SetParameter("RobotSpeed", .05f);
        }
        else
        {
            emitterDriving.SetParameter("RobotSpeed", speed);
            if (!emitterDriving.IsPlaying())
                emitterDriving.Play();
        }

        if (movementInput.magnitude < 0.5f)
            previousAudioSpeed = speed - ((1f / 2f) * Time.fixedDeltaTime);
        else
            previousAudioSpeed = speed;

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
        if (!interactable.CanInteractWith())
        {
            return;
        }

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
