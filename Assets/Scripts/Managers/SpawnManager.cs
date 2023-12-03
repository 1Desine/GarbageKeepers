using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    static public SpawnManager Instance { get; private set; }

    [SerializeField] GameObject playerPrefab;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        Instance = this;

        SpawnObject(playerPrefab, Vector3.zero, Quaternion.identity);
    }

    static public GameObject SpawnObject(GameObject obj, Vector3 position, Quaternion rotation) {
        return Instantiate(obj, position, rotation);
    }


}
