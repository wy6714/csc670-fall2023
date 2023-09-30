using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    int rows = 20;
    int columns = 20;
    Cell[,] cells;
    float cellWidth = 1f;
    float spacing = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        cells = new Cell[rows, columns];
        

        for(int x = 0; x < rows; x++)
        {
            for (int y=0; y<rows; y++)
            {
                //create cellobj
                Vector3 pos = transform.position;
                pos.x = pos.x + x * (cellWidth + spacing);
                pos.z = pos.z + y * (cellWidth + spacing);
                GameObject cellObj = Instantiate(cellPrefab, pos, transform.rotation);

                //cells info
                cells[x, y] = cellObj.GetComponent<Cell>();
                cells[x, y].x = x;
                cells[x, y].y = y;
                cells[x, y].neighbors = 0;
                cells[x, y].state = Random.Range(0,2);
                
                Debug.Log("x: " + cells[x, y].x + " y: " + cells[x, y].y + " state: " + cells[x, y].state);  
                
            }
        }

        countNeghbors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void countNeghbors()
    {
        for(int x =0; x<rows; x++)
        {
            for(int y =0; y< rows; y++)
            {
                int neighbors = 0;
                //up
                if(y+1 < rows)
                {
                    neighbors += cells[x, y+1].state;
                }
                //right
                if(x+1 < rows)
                {
                    neighbors += cells[x+1, y].state;
                }
                //down
                if (y - 1 >= 0)
                {
                    neighbors += cells[x, y-1].state;
                }
                //left
                if (x - 1 >= 0)
                {
                    neighbors += cells[x-1, y].state;
                }
                //right top
                if(x+1<rows && y+1 < rows)
                {
                    neighbors += cells[x+1, y+1].state;
                }
                //left top
                if(x-1 > 0 && y+1 < rows)
                {
                    neighbors += cells[x - 1, y + 1].state;
                }
                //rigot down
                if(x+1 < rows && y - 1 > 0)
                {
                    neighbors += cells[x + 1, y - 1].state;
                }
                //left down
                if(x-1 >0 && y-1 > 0)
                {
                    neighbors += cells[x - 1, y - 1].state;
                }

                cells[x, y].neighbors = neighbors;
            }
        }
    }

    
    
    
}

