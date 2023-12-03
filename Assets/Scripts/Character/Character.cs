using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Character : Entity {

    private Inventory inventory;
    private PlayerController playerController;
    [SerializeField] GameObject visual;

    [SerializeField] float reachDistance = 3f;

    public RaidTask raidTask = null;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        health = 100;
        entityName = "Character";

        inventory = GetComponent<Inventory>();
        playerController = GetComponent<PlayerController>();

        SetGameLayerRecursive(visual, 7);
    }


    private void Start() {
        GameManager.RegisterCharacter(this);
        GameManager.PlaceCharacterAtSpawnPosition(this);
    }
    private void OnDestroy() {
        GameManager.Unregistercharacter(this);
    }
    private void OnEnable() {
        InputManager.OnMainActionB += InputManager_OnMainActionB;
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    private void OnDisable() {
        InputManager.OnMainActionB -= InputManager_OnMainActionB;
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) {
        GameManager.PlaceCharacterAtSpawnPosition(this);
    }
    private void InputManager_OnMainActionB() {
        if (!playerController.LookingAt(reachDistance, out RaycastHit hit)) return;

        if (hit.transform.root.TryGetComponent(out IInteractable interactable))  {
            interactable.Interact(gameObject);
            Debug.Log("Interacted");
        }

    }


    private void SetGameLayerRecursive(GameObject _go, int _layer) {
        _go.layer = _layer;
        foreach (Transform child in _go.transform) {
            child.gameObject.layer = _layer;

            Transform _HasChildren = child.GetComponentInChildren<Transform>();
            if (_HasChildren != null)
                SetGameLayerRecursive(child.gameObject, _layer);

        }
    }

    protected override void PrepairAndDie() {
        if (inventory.cells.Count != 0)
            foreach (var cell in inventory.cells)
                if (cell.inventoryItemSO != null)
                    itemsToDropOnDied.Add(cell.inventoryItemSO);
        base.PrepairAndDie();
    }


}
