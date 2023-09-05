using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 75f;
    public float timeLeft = 20;
    public int intTimeLeft;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI WinText;
    public Rigidbody rb;
    public float jumpForce = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        WinText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        if (timeLeft > 0)
        {
            gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * -vAxis, Space.World);
            gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

            timeLeft -= Time.deltaTime;
            intTimeLeft = (int)Mathf.Round(timeLeft);
            TimerText.text = intTimeLeft.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("battery"))
        {
            timeLeft += 5;
            Destroy(other.gameObject);
            //TimerText.text = intTimeLeft.ToString();
      
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("winChecker"))
        {
            WinText.enabled = true;
        }
    }
}