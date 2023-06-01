using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 5;
    public int rotationSpeed = 10;
    public int jumpSpeed = 10;
    public int jumpGracePeriod = 10;

    private Animator animator;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Get input from keyboard
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move player
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
            //transform.forward = movement;
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        controller.Move(movementDirection * speed * Time.deltaTime);

        // Rotate player
        Vector3 rotation = new Vector3(0, horizontal * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);

        // Jump
        // if (Input.GetButtonDown("Jump") && controller.isGrounded)
        // {
        //     StartCoroutine(Jump());
        // }

    }
}
