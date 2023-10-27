using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public Transform attackChecker;
    public LayerMask groundMask;

    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.4f;

    private bool isGrounded;
    private Vector3 velocity;
    public int count = 0;

    public GameObject starRoad;

    private void Start()
    {
        starRoad.SetActive(false);
    }

    void Update()
    {
        if (count > 2)
        {
            starRoad.SetActive(true);
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

     
        
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        


        attackChecker.position = groundCheck.position;

        


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log("player die");
            //Destroy(gameObject);
        }

        if (other.CompareTag("star"))
        {
            Destroy(other.gameObject);
            count += 1;
        }
    }
}
