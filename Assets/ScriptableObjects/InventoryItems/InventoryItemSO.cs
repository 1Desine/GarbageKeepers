using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class InventoryItemSO : ScriptableObject {

    public GameObject prefab;
    public Sprite sprite;


    public List<Inventory.Cell.CellType> compatibleCellsByType;
    
    

}
