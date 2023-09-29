using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public bool alive = false;

    public Color aliveColor;
    public Color deadColor;

    private Renderer rend;

    public int x = -1;
    public int y = -1;

    GameOfLife gol;

    // Start is called before the first frame update
    void Start()
    {
        GameObject golObj = GameObject.Find("GameOfLifeObj");
        gol = golObj.GetComponent<GameOfLife>();
        rend = gameObject.GetComponentInChildren<Renderer>();
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateColor()
    {
        if (alive)
        {
            rend.material.color = aliveColor;
        }
        else
        {
            rend.material.color = deadColor;
        }
    }
    
}
