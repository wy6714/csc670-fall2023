using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public AudioSource bgm;
    public GameObject creditPanel;
    // Start is called before the first frame update
    void Start()
    {
        bgm.Play();
        creditPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("play");
    }
    public void opencredit()
    {
        creditPanel.SetActive(true);
    }

    public void closeCiredit()
    {
        creditPanel.SetActive(false);
    }
}
