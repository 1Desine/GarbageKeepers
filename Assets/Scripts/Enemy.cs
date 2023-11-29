using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    [SerializeField] private List<InventoryItemSO> posibleItemsToDrop;

    private void Awake() {
        entityName = "Enemy";
    }

    protected override void PrepairItemsToDropAndDie() {
        if (posibleItemsToDrop.Count != 0) itemsToDropOnDied.Add(posibleItemsToDrop[Random.Range(0, posibleItemsToDrop.Count)]);
        base.PrepairItemsToDropAndDie();
    }

}
