using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator playerAnimator;
    public float speed = 6f;
    public float smoothTime = 0.1f;
    public float gravity = -3f;

    private Vector3 velocity;
    private float turnSmoothVelocity;
    private Transform cam;
    private Player playerInput;

    private void Awake()
    {
        playerInput = new Player();
        playerInput.Enable();
    }

    private void Start()
    {
        cam = Camera.main.transform;

        playerAnimator.SetBool("Walking", false);
    }

    private void Update()
    {
        Movement();

        if(Keyboard.current[Key.Digit1].wasPressedThisFrame)
        {
            playerAnimator.SetTrigger("Thumbs Up");
        }
        if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
        {
            playerAnimator.SetTrigger("Thinking");
        }
        if (Keyboard.current[Key.Digit3].wasPressedThisFrame)
        {
            playerAnimator.SetTrigger("Dancing");
        }
        if (Keyboard.current[Key.Digit4].wasPressedThisFrame)
        {
            playerAnimator.SetTrigger("Wave Hand");
        }
    }

    public void Movement()
    {
        Vector2 moveInput = playerInput.PlayerControl.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);

        if (direction.magnitude >= 0.1f)
        {
            playerAnimator.SetBool("Walking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        }
        else
        {
            playerAnimator.SetBool("Walking", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
