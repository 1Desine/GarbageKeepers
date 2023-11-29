using System.Collections.Generic;
using UnityEngine;

public class Haron : MonoBehaviour {


    private List<ItemObject> items;

    private int minItemsWaightToExit;


    public void AddItem() {


        int itemsWeight = 0;
        foreach (ItemObject item in items) {
            itemsWeight += 1; //item.weight
        }
        if (itemsWeight >= minItemsWaightToExit) {
            // start exid animation
        }
    }




}
