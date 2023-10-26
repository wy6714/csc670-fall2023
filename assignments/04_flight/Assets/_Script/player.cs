using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed = 10f;
    [SerializeField] Transform isGroundChecker;
    [SerializeField] Transform Ground;
    [SerializeField] bool isGround;
    private float jumpForce = 200f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        GroundChecker();
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (isGround)
        {
            characterController.Move(move * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0.0f, 45f, 0.0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0.0f, -45f, 0.0f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0.0f, 0f, 0.0f);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                characterController.Move(Vector3.up * jumpForce * Time.deltaTime);
            }
        }

        if (!isGround)
        {
            characterController.Move(Vector3.down * 9.8f * Time.deltaTime);
        }

    }

    private bool GroundChecker()
    {
        float isGroundCheckerY = isGroundChecker.transform.position.y;
        float GroundY = Ground.transform.position.y;
        float fromGround = isGroundCheckerY - GroundY;
        if (fromGround <= 0.1)
        {
           isGround = true;
        }
        else
        {
            isGround = false;
        }

        return isGround;
    }
}
