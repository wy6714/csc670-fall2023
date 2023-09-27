using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    public CellScript[,] cells;
    private float cellWidth = 1f;
    private float space = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x<20; x++)
        {
            for(int y =0; y<20; y++)
            {
                Vector3 pos = transform.position;
                pos.x = pos.x + x * (cellWidth+space);
                pos.z = pos.z + y * (cellWidth+space);
                GameObject cellObj = Instantiate(cellPrefab, pos, transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
