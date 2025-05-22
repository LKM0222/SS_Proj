using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    NONE = 0,
    ITEM = 1,
}

[System.Serializable]
public class Dispenser_Item
{
    public ItemType itemType;
    public float spawnTime;
    public string name;
}
