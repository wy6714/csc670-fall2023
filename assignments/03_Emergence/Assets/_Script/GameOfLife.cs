using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    int rows = 20;
    int columns = 20;
    Cell[,] cells;
    //public GameObject[,] cellObjs; 
    float cellWidth = 1f;
    float spacing = 0.1f;
    Renderer rend;
    public Color aliveColor;
    public Color deadColor;

    // Start is called before the first frame update
    void Start()
    {
        cells = new Cell[rows, columns];
        //cellObjs = new GameObject[rows, columns];

        for(int x = 0; x < rows; x++)
        {
            for (int y=0; y<rows; y++)
            {
                //cells info
                cells[x, y] = new Cell();
                cells[x, y].x = x;
                cells[x, y].y = y;
                cells[x, y].state = Random.Range(0,2);
                
                Debug.Log("x: " + cells[x, y].x + " y: " + cells[x, y].y + " state: " + cells[x, y].state);

                //cells obj
                Vector3 pos = transform.position;
                pos.x = pos.x + x * (cellWidth + spacing);
                pos.z = pos.z + y * (cellWidth + spacing);
               
                GameObject cellObj = Instantiate(cellPrefab, pos, transform.rotation);
                cells[x, y].cell = cellObj;
                rend = cells[x, y].cell.GetComponentInChildren<Renderer>();
                updateColor(cells[x, y].state);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        countNeghbors();
    }

    public int countNeghbors()
    {
        int neighbors = 0;

        return neighbors;
    }

    
    void updateColor(int alive)
    {
        if (alive == 1)
        {
            rend.material.color = aliveColor;
        }
        else
        {
            rend.material.color = deadColor;
        }
    }
    
}
