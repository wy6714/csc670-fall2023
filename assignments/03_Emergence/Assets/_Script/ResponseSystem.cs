using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResponseSystem : MonoBehaviour,IObserver
{
    [SerializeField] Subject subject;
    public bool timeOn = true;
    public float timeNum=0;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI winText;
    public GameObject winBox;

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (Subject subject in FindObjectsOfType<Subject>())
        {
            subject.AddObservor(this);
        }

        

    }
    void Update()
    {
        if (timeOn)
        {
            winBox.SetActive(false);
            timeNum += Time.deltaTime;
            TimerText.text = "Time: " + timeNum.ToString();
            Debug.Log("time on" + timeNum);
        }
        else
        {
            winBox.SetActive(true);
            TimerText.text = "Time: " + timeNum.ToString();
            winText.text = "You Spend: " + timeNum.ToString() + "seconds!";
        }
        
    }

    public void OnNotify(Actions actions)
    {

        switch (actions)
        {
            case (Actions.Win):
                timeOn = false;
                return;

            default:
                return;
        }
        
        
    }

   

}
