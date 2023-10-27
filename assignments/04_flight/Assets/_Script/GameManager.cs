using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //check distance && getBroom, set player model active on broom
    // Start is called before the first frame update
    public GameObject broomMegaObj;
    public GameObject broomObj;
    public GameObject playerObj;
    public Camera cameraPos;
    public bool onBroom = false;
    public GameObject taskPanel;
    void Start()
    {
        broomMegaObj.SetActive(false);
        taskPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float broomToPlayer = Vector3.Distance(broomMegaObj.transform.position,
            playerObj.transform.position);

        if(broomToPlayer <1 && Input.GetKeyUp(KeyCode.E) && !onBroom)
        {
            cameraPos.transform.parent = broomObj.transform;
            onBroom = true;
            broomMegaObj.SetActive(true);
            playerObj.SetActive(false);
        }
        
    }
    public void closeTask()
    {
        taskPanel.SetActive(false);
    }

    public void opentask()
    {
        taskPanel.SetActive(true);
    }
}
