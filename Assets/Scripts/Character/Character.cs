using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Character : Entity {

    private Inventory inventory;
    private PlayerController playerController;
    [SerializeField] GameObject visual;

    [SerializeField] float reachDistance = 3f;

    private RaidTask raidTask;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        health = 100;
        entityName = "Character";

        inventory = GetComponent<Inventory>();
        playerController = GetComponent<PlayerController>();

        SetGameObjectLayerRecursive(visual, 7);
    }
    private void Start() {
        GameManager.RegisterCharacter(this);
    }
    private void OnDestroy() {
        GameManager.Unregistercharacter(this);
    }
    private void OnEnable() {
        InputManager.OnMainActionB += InputManager_OnMainActionB;
    }
    private void OnDisable() {
        InputManager.OnMainActionB -= InputManager_OnMainActionB;
    }
    private void InputManager_OnMainActionB() {
        if (!playerController.LookingAt(reachDistance, out RaycastHit hit)) return;

        if (hit.transform.root.TryGetComponent(out IInteractable interactable)) {
            interactable.Interact(gameObject);
        }
    }

    private void SetGameObjectLayerRecursive(GameObject obj, int layer) {
        obj.layer = layer;
        foreach (Transform child in obj.transform) {
            child.gameObject.layer = layer;

            Transform hasChildren = child.GetComponentInChildren<Transform>();
            if (hasChildren != null) SetGameObjectLayerRecursive(child.gameObject, layer);
        }
    }

    protected override void PrepairAndDie() {
        if (inventory.cells.Count != 0)
            foreach (var cell in inventory.cells)
                if (cell.inventoryItemSO != null)
                    itemsToDropOnDied.Add(cell.inventoryItemSO);
        base.PrepairAndDie();
    }



    public RaidTask GetRaidTask() => raidTask;
    public void SetRaidTask(RaidTask raidTask) => this.raidTask = raidTask;

}
