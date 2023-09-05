using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 75f;
    public float timeLeft = 20;
    public int intTimeLeft;
    public TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
      
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

        
    }
}
