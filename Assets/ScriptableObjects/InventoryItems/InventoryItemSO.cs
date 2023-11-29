using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class InventoryItemSO : ScriptableObject {

    public GameObject prefab;
    public Sprite sprite;

    public string itemName;
    public Tag tag;

    public List<Inventory.Cell.CellType> compatibleCellsByType;
    
    public enum Tag {
        None,
        Weapon,
        QuickUse,
        Clothing,
    }
    

}
