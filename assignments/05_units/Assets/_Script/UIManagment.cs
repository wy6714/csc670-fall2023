using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagment : MonoBehaviour
{
    public TMP_Text fruitNumText;
    public static int fruitNum;

    private void OnEnable()
    {
        fruitNum = 6;
        fruitNumText.text = ":" + fruitNum.ToString();
        Grid.updateFruit += UpdateFruitText;
    }

    private void OnDisable()
    {
        Grid.updateFruit -= UpdateFruitText;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateFruitText(int cost)
    {
        fruitNum -= cost;
        fruitNumText.text = ":" + fruitNum.ToString();
    }
}
