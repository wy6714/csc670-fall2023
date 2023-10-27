using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomController : MonoBehaviour
{
    public float speed = 2f;
    public float rotateAmount = 120f;
    private float rotateValue;
    public bool getBroom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (getBroom)
        {
            //move forward
            transform.position += transform.forward * speed * Time.deltaTime;

            //rotate
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
            rotateValue += hInput * rotateAmount * Time.deltaTime;

            //Mathf.Sign decides go up or down based on value of vInput's negative or positive
            //up and down 0-20 degree
            float pitch = Mathf.Lerp(0, 20, Mathf.Abs(vInput)) * Mathf.Sign(vInput);

            //roll
            float roll = Mathf.Lerp(0, 30, Mathf.Abs(hInput)) * Mathf.Sign(hInput);
            transform.localRotation = Quaternion.Euler(Vector3.up * rotateValue
                + Vector3.right * pitch
                + Vector3.forward * roll);
        }
        


    }
}
