using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{

    public struct Cell
    {
        public bool isalive;
        public int x;
        public int y;

        public Cell(bool cellStatus, int IndexX, int IndexY)
        {
            isalive = cellStatus;
            x = IndexX;
            y = IndexY;
        }

    }
}
