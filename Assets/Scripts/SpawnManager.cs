using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    static public SpawnManager Instance { get; private set; }


    private void Awake() {
        Instance = this;
    }

    public void SpawnObject(GameObject obj, Vector3 position, Quaternion roitation) {
        Instantiate(obj, position, roitation);
    }
    public void DropInventoryItem(InventoryItemSO inventoryItemSO, Vector3 desiredPosition) {
        if (Physics.Raycast(desiredPosition, Vector3.down, out RaycastHit hit)) {
            desiredPosition = hit.point;
            SpawnObject(inventoryItemSO.prefab, desiredPosition, Quaternion.Euler(hit.normal));
        } else {
            Debug.LogError("me. Can't drop item");
        }
    }


}
