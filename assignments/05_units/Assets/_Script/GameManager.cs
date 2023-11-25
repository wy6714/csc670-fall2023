using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private int flagNum = 0;

    public GameObject champion;

    public GameObject currentBlock;
    public GameObject normal;
    public GameObject spikes;
    public GameObject jumpBlock;

    private string selected;

    public static event Action<GameObject> WinHappened;

    void Awake()
    {
        gm = this;
        champion.SetActive(false);
    }
    private void OnEnable()
    {
        PlayerController.GetFlag += UpdateFlagNum;
        PlayerController.GetFlag += FlagAnim;
        WinHappened += showChampion;
    }

    private void OnDisable()
    {

        PlayerController.GetFlag -= UpdateFlagNum;
        WinHappened -= showChampion;
    }
    // Start is called before the first frame update
    void Start()
    {
        selected = "null";
        currentBlock = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagNum == 2)
        {
            WinHappened?.Invoke(champion);
        }
    }

    public void UpdateFlagNum(GameObject obj)
    {
        Flag objScript = obj.GetComponent<Flag>();
        flagNum += objScript.num;
        objScript.num = 0;
    }

    public void showChampion(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void FlagAnim(GameObject obj)
    {
        Animator objAnim = obj.GetComponent<Animator>();
        objAnim.SetBool("NoFlag", true);
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

    public void JumpButton()
    {
        currentBlock = jumpBlock;
        selected = "jump";
        Debug.Log(selected);
    }

    
    
}
