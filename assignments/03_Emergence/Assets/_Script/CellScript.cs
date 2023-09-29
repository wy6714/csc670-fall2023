using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public bool alive = false;

    public Color aliveColor;
    public Color deadColor;

    private Renderer rend;

    public int x = 0;
    public int y = 0;

    GameOfLife gol;

    public Cases cellPositionType;

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

    private int CountNeighbor(Cases cellPositionCase)
    {
        int alive = 0;
        switch (cellPositionCase)
        {
        //    case (Cases.case00):
        //        for (int xIndex = 0; xIndex <= x+2; xIndex++)
        //        {
        //            for(int yIndex = 0; yIndex <= y+2; yIndex++)
        //            {
        //                if (gol.cellArray[xIndex, yIndex].alive)
        //                {
        //                    alive++;
        //                }
        //            }
        //        }
        //        return alive;

        //    case (Cases.case01):
        //        for(int xIndex = x-1; xIndex<x+1; xIndex++)
        //        {
        //            for(int yIndex = 0; yIndex<= y+1; yIndex++)
        //            {
        //                if (gol.cellArray[xIndex, yIndex].alive)
        //                {
        //                    alive++;
        //                }
        //            }
        //        }
        //        return alive;

        //    case (Cases.case019):
        //        for (int xIndex = 0; xIndex<x+2; xIndex++)
        //        {
        //            for (int yIndex = 19; yIndex <= y; yIndex++)
        //            {
        //                if (gol.cellArray[xIndex, yIndex].alive)
        //                {
        //                    alive++;
        //                }
        //            }
        //        }
        //        return alive;

            case (Cases.caseMiddle)://done
                for(int xIndex = x-1; xIndex <= x+1; xIndex++)
                {
                    for (int yIndex = y-1; yIndex <= y+1; yIndex++)
                    {
                        if (gol.cellArray[xIndex, yIndex].alive)
                        {
                            alive++;
                        }
                    }
                }
                return alive;

            default:
                return alive;
        }
        
    }


    private void OnMouseDown()
    {
        alive = !alive;
        UpdateColor();
        Cases cellPositionType = this.cellPositionType;
        Debug.Log(CountNeighbor(cellPositionType));
        Debug.Log("x: " + this.x + "y: " + this.y);
    }

    
}
