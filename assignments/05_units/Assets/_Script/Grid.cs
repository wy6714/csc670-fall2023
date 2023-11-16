using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int width;
    public int height;
    public bool selected;

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.selected = false;
    }
}
