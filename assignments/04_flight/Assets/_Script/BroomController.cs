using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomController : MonoBehaviour
{
    public float speed = 2f;
    public float rotateAmount = 120f;
    private float rotateValue;
    public GameManager gm;

    public float energy = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.onBroom)
        {
            //move forward
            transform.position += transform.forward * speed * Time.deltaTime;

            //rotate
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
            rotateValue += hInput * rotateAmount * Time.deltaTime;

            //Mathf.Sign decides go up or down based on value of vInput's negative or positive
            //up and down 0-20 degree
            float pitch = Mathf.Lerp(0, 20, Mathf.Abs(vInput)) * -Mathf.Sign(vInput);

            //roll
            float roll = Mathf.Lerp(0, 30, Mathf.Abs(hInput)) * Mathf.Sign(hInput);
            transform.localRotation = Quaternion.Euler(Vector3.up * rotateValue
                + Vector3.right * pitch
                + Vector3.forward * roll);
        }

        if (energy > 100)
        {
            energy = 100;
        }
        


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("energy"))
        {
            Destroy(other.gameObject);
            energy += 20;
        }
    }
}
