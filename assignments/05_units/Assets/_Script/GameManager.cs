using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blockObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectBlock()
    {
        
        GameObject block = Instantiate(blockObj, GetMousePos(), transform.rotation);
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0f;
        Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return MouseWorldPosition;
    }
}
