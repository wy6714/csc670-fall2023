using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseSystem : MonoBehaviour,IObserver
{

    // Start is called before the first frame update
    void Start()
    {
        foreach(Subject subject in FindObjectsOfType<Subject>())
        {
            subject.AddObservor(this);
        }
    }

    public void OnNotify(GameObject obj, Actions actions)
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
