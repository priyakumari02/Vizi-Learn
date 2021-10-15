using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    //public Animator playerAnim;

    public float speed = 6f;
    public float smoothTime = 0.1f;
    public float gravity = -3f;

    Vector3 velocity;

    float turnSmoothVelocity;
    public Transform cam;

    private Player playerInput;

    private void Awake()
    {
        playerInput = new Player();
        playerInput.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        //playerAnim = GetComponent<Animator>();

        //playerAnim.SetInteger("Walk", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        /*float horizontal, vertical;
        //keyboard
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        */

        Vector2 moveInput = playerInput.PlayerControl.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);

        if (direction.magnitude >= 0.1f)
        {
            //playerAnim.SetInteger("Walk", 1);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        }

        else
        {
            //playerAnim.SetInteger("Walk", 0);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}