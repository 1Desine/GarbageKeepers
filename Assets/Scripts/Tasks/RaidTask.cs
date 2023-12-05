using System;
using System.Collections.Generic;

[Serializable]
public class RaidTask {

    public List<InventoryItemSO> itemsToFind;


    public bool IsEnoughItemsCollected(List<InventoryItemSO> itemsCollected) {
        Dictionary<InventoryItemSO, int> foundItemsWithAmount = new();
        foreach (InventoryItemSO item in itemsCollected) {
            if (foundItemsWithAmount.ContainsKey(item)) foundItemsWithAmount[item]++;
            else foundItemsWithAmount.Add(item, 1);
        }

        bool foundEnough = true;
        foreach (InventoryItemSO item in itemsToFind) {
            if (foundItemsWithAmount.ContainsKey(item)) {
                if (foundItemsWithAmount[item] <= 0) foundEnough = false;
                foundItemsWithAmount[item]--;
            }
            else foundEnough = false;
        }

        return foundEnough;
    }

}
