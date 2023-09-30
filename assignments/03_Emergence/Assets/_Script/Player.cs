using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            pos.z = pos.z + 1.1f;
            transform.position = pos;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            pos.z = pos.z - 1.1f;
            transform.position = pos;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            pos.x = pos.x - 1.1f;
            transform.position = pos;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            pos.x = pos.x + 1.1f;
            transform.position = pos;
        }
    }
}
