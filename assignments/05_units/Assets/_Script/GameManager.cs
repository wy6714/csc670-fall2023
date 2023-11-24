using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject currentBlock;
    public GameObject normal;
    public GameObject spikes;

    private string selected;

    void Awake()
    {
        gm = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        selected = "null";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpikesButton()
    {
        currentBlock = spikes;
        selected = "spikes";
        Debug.Log(selected);
    }

    public void NormalButton()
    {
        currentBlock = normal;
        selected = "normal";
        Debug.Log(selected);
    }

    
    
}
