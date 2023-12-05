using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    static public Level Instance { get; private set; }

    [SerializeField] Transform spawnPositionsHolder;

    private void Awake() {
        Instance = this;
    }

    static public List<Transform> GetSpawnPositions() {
        List<Transform> spawnPositions = new List<Transform>();
        foreach (Transform child in Instance.spawnPositionsHolder) spawnPositions.Add(child);
        return spawnPositions;
    }


}
