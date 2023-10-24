using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;
    bool isFly;
    CharacterController characterController;
    [SerializeField] Transform broomSeat;
    // Start is called before the first frame update
    void Start()
    {
        isFly = false;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Broom") && Input.GetKeyUp(KeyCode.Space) && !isFly)
        {
            isFly = true;
            transform.position = broomSeat.position;
        }

        if(other.CompareTag("Broom") && Input.GetKeyUp(KeyCode.Space) && isFly)
        {
            isFly = false;
        }
            
    }

    void PlayerMove()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * speed * Time.deltaTime);
    }
}
