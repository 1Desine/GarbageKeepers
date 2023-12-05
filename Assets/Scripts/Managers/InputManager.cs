using System;
using UnityEngine;

public class InputManager : MonoBehaviour {
    static public InputManager Instance { get; private set; }


    static public Action OnJumpDown = () => { };
    static public Action OnAttackDown = () => { };
    static public Action<Vector2> OnInventoryDropItemDown = (_) => { };
    static public Action OnMainActionB = () => { };
    static public Action<int> OnUseQuickSlot = (_) => { };


    private InputActions inputActions;

    static public Action<InputState> OnInputStateChange = _ => { };

    private InputState inputState = InputState.Character;
    public enum InputState {
        Character,
        Inventory,
        Settings,
    }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        inputActions = new InputActions();
        inputActions.Enable();

        inputActions.Character.Jump.started += _ => OnJumpDown();
        inputActions.Character.Attack.started += _ => OnAttackDown();
        inputActions.Character.MainActionB.started += (_) => OnMainActionB();
        inputActions.Character.QuickSlot1.started += (_) => OnUseQuickSlot(0);
        inputActions.Character.QuickSlot2.started += (_) => OnUseQuickSlot(1);
        inputActions.Character.QuickSlot3.started += (_) => OnUseQuickSlot(2);

        inputActions.Inventory.DropItemB.started += (_) => OnInventoryDropItemDown(inputActions.Inventory.CursorV2.ReadValue<Vector2>());
        inputActions.Inventory.InventoryB.started += (_) => ChangeState(InputState.Inventory);
    }
    static public Vector2 MoveV2N() => Instance.inputActions.Character.MoveV2N.ReadValue<Vector2>();
    static public Vector2 LookV2D() => Instance.inputActions.Character.LookV2D.ReadValue<Vector2>();
    static public bool GetSpringButton() => Instance.inputActions.Character.SprintB.inProgress;


    static public void PlayerSpawned() {
        Instance.ChangeState(InputState.Character);
    }
    private void ChangeState(InputState inputState) {
        if (this.inputState == inputState) {
            this.inputState = InputState.Character;
            inputActions.Character.Attack.Enable();
            inputActions.Character.MoveV2N.Enable();
            inputActions.Character.LookV2D.Enable();

            inputActions.Inventory.DropItemB.Disable();

            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            switch (inputState) {
                case InputState.Inventory: {
                    this.inputState = InputState.Inventory;
                    inputActions.Character.Attack.Disable();
                    inputActions.Character.LookV2D.Disable();

                    inputActions.Inventory.DropItemB.Enable();

                    Cursor.lockState = CursorLockMode.None;

                    break;
                }
                case InputState.Settings: {
                    this.inputState = InputState.Settings;
                    inputActions.Character.Attack.Disable();
                    inputActions.Character.MoveV2N.Disable();
                    inputActions.Character.LookV2D.Disable();

                    break;
                }
            }
        }

        OnInputStateChange(this.inputState);
    }

}
