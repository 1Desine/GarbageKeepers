using UnityEngine;
using UnityEngine.UI;

public class SpawnUI : MonoBehaviour {
    static public SpawnUI Instance { get; private set; }

    [SerializeField] Button spawnButton;

    private void Awake() {
        Instance = this;

        spawnButton.onClick.AddListener(() => {
            SpawnManager.SpawnPlayer();
            InputManager.PlayerSpawned();
            Hide();
        });
    }



    private void Hide() {
        gameObject.SetActive(false);
    }

}
