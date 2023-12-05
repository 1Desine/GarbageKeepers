using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISystem : MonoBehaviour {
    static public UISystem Instance { get; private set; }

    [SerializeField] EventSystem eventSystem;
    [SerializeField] InventoryUI inventoryUI;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        eventSystem.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(true);
    }





}
