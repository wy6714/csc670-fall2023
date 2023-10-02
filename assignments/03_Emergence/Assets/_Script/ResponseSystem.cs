using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResponseSystem : MonoBehaviour,IObserver
{


    // Start is called before the first frame update
    void Start()
    {
        foreach (Subject subject in FindObjectsOfType<Subject>())
        {
            subject.AddObservor(this);
        }
    }

    public void OnNotify(Actions actions)
    {

        switch (actions)
        {
            case (Actions.gameOver):

                SceneManager.LoadScene("gameOverScene");
                return;

            default:
                return;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


}
