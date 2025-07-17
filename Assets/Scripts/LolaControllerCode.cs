using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LolaControllerCode : MonoBehaviour
{
    PlayerInput playerInput;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 velocity;
    bool isMovementPressed;
    bool isGrounded;
    CharacterController characterController;
    Animator animator;
    public CinemachineFreeLook cinemachineFreeLook;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float rotationSpeed = 1f;
    public float gravity = -9.81f;
    public float lookSpeed = 2f;
    public float xRotationLimit = 90f; // Limit vertical rotation
    private Transform playerCamera;
    void Awake()
    {
        playerInput = new PlayerInput();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<CinemachineFreeLook>().transform;

        playerInput.CharacterController.Move.started += onMovement;
        playerInput.CharacterController.Move.canceled += onMovement;
        playerInput.CharacterController.Move.performed += onMovement;
        playerInput.CharacterController.Jump.started += onJump;
        playerInput.CharacterController.Look.performed += OnLook;
        playerInput.CharacterController.Look.canceled += OnLook;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        void onMovement(InputAction.CallbackContext context)
        {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        }

        void onJump(InputAction.CallbackContext context)
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small value to keep the character grounded
        }

        // Movement
        Vector3 move = cinemachineFreeLook.transform.right * currentMovement.x + cinemachineFreeLook.transform.forward * currentMovement.z;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        // Rotation to always face the camera's forward direction
        if (cinemachineFreeLook != null)
        {
            Vector3 cameraForward = transform.forward;
            cameraForward.y = 0f; // Keep the character upright

            if (cameraForward != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        // Animation logic
        bool isMoving = currentMovement != Vector3.zero;
        animator.SetBool("IsForwardRunning", isMoving && currentMovement.z > 0);
        animator.SetBool("IsBackwardRunning", isMoving && currentMovement.z < 0);
        animator.SetBool("IsRunJumping", isMoving && !isGrounded && velocity.y > 0);
        animator.SetBool("IsStandJumping", !isMoving && !isGrounded && velocity.y > 0);
    }
    private void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        float mouseX = lookInput.x;
        float mouseY = lookInput.y;

        // Horizontal rotation (yaw)
        transform.Rotate(Vector3.up * mouseX * lookSpeed);
    }

    void OnEnable()
    {
        playerInput.CharacterController.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterController.Disable();
    }
}