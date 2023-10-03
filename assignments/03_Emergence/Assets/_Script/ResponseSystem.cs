using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResponseSystem : MonoBehaviour,IObserver
{
    [SerializeField] Subject subject;
    [SerializeField] bool timeOn=true;
    float timeNum=0;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI winText;
    public GameObject winBox;
    public GameObject playButtonObj;

    // Start is called before the first frame update
    void Start()
    {
        timeOn = true;
        winText.text = "Ready to Start?";

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
            //winText.text = "Ready to Start?";
        }
        
    }

    public void OnNotify(Actions actions)
    {

        switch (actions)
        {
            case (Actions.Win):
                timeOn = false;
                winText.text = "You Spend: " + timeNum.ToString() + " seconds!";
                return;

            default:
                return;
        }
        
        
    }

    public void playButton()
    {
        timeOn = true;
        playButtonObj.SetActive(false);
    }

   

}
