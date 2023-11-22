using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Block : MonoBehaviour
{
    public string name;
    public GameObject normalBlock;
    private GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0f;
        Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (block != null)
        {
            block.transform.position = MouseWorldPosition; 
        }
    }

    private void OnMouseDown()
    {
        
        block = Instantiate(normalBlock, transform.position, transform.rotation);
        
    }
}
