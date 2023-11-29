using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    static public SpawnManager Instance { get; private set; }


    private void Awake() {
        Instance = this;
    }

    static public void SpawnObject(GameObject obj, Vector3 position, Quaternion roitation) {
        Instantiate(obj, position, roitation);
    }
    static public bool TryDropInventoryItem(InventoryItemSO inventoryItemSO, Vector3 desiredPosition) {
        if (Physics.Raycast(desiredPosition, Vector3.down, out RaycastHit hit)) {
            SpawnObject(inventoryItemSO.prefab, hit.point, Quaternion.Euler(hit.normal));
            Debug.Log(hit.point);
            return true;
        }
        else {
            Debug.LogError("me. Can't drop item");
            return false;
        }
    }


}
