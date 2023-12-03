using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    static public SpawnManager Instance { get; private set; }

    [SerializeField] GameObject playerPrefab;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        Instance = this;
    }
    private void Start() {
        Character character = SpawnObject(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Character>();
        GameManager.PlaceCharacterAtSpawnPosition(character);
    }

    static public GameObject SpawnObject(GameObject obj, Vector3 position, Quaternion roitation) {
        return Instantiate(obj, position, roitation);
    }
    static public bool TryDropInventoryItem(InventoryItemSO inventoryItemSO, Vector3 desiredPosition) {
        if (Physics.Raycast(desiredPosition, Vector3.down, out RaycastHit hit)) {
            SpawnObject(inventoryItemSO.prefab, hit.point, Quaternion.Euler(hit.normal));
            return true;
        }
        else {
            Debug.LogError("me. Can't drop item");
            return false;
        }
    }


}
