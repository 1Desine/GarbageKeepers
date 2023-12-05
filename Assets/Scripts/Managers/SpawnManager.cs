using UnityEngine;

public class SpawnManager : MonoBehaviour {
    static public SpawnManager Instance { get; private set; }

    [SerializeField] GameObject playerPrefab;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    static public GameObject SpawnObject(GameObject obj, Vector3 position, Quaternion rotation) {
        return Instantiate(obj, position, rotation);
    }
    static public void SpawnPlayer() {
        SpawnObject(Instance.playerPrefab, Vector3.zero, Quaternion.identity);
    }

}
