using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    public CellScript[,] cellArray; //array, stored data type is cellScript
    //public Cells[,] cellArray;
    private float cellWidth = 1f;
    private float space = 0.1f;
 
    // Start is called before the first frame update
    void Start()
    {
        cellArray = new CellScript[20, 20];
        //cellArray = new Cells[20, 20];

        for(int x = 0; x<20; x++)
        {
            for(int y =0; y<20; y++)
            {
                Vector3 pos = transform.position;
                pos.x = pos.x + x * (cellWidth+space);
                pos.z = pos.z + y * (cellWidth+space);
                GameObject cellObj = Instantiate(cellPrefab, pos, transform.rotation);
                cellArray[x, y] = cellObj.GetComponent<CellScript>();
                cellArray[x, y].x = x;
                cellArray[x, y].y = y;
                cellArray[x, y].alive = (Random.value < 0.2f);

                //cellArray[x, y] = new Cell((Random.value < 0.2f), x, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
