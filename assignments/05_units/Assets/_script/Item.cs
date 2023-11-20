using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="GameObject/Item")]
public class Item : ScriptableObject
{
    public TileBase tile;
    public Sprite image;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5,4);
}

public enum ItemType { BuildingBlock, Tool}

public enum ActionType{Dig, Mine}
