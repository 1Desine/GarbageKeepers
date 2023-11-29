using System;
using UnityEngine;

public class InputManager : MonoBehaviour {
    static public InputManager Instance { get; private set; }


    private InputActions inputActions;

    static public Action OnJumpDown = () => { };
    static public Action OnAttackDown = () => { };
    static public Action<Vector2> OnInventoryDropItemDown = (_) => { };
    static public Action OnPickUpItem = () => { };
    static public Action<int> OnUseQuickSlot = (_) => { };

    private InputState inputState = InputState.Character;
    private enum InputState {
        Character,
        Inventory,
        Settings,
    }

    private void Awake() {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Enable();

        inputActions.Character.Jump.started += _ => OnJumpDown();
        inputActions.Character.Attack.started += _ => OnAttackDown();
        inputActions.Character.PickUpItemB.started += (_) => OnPickUpItem();
        inputActions.Character.QuickSlot1.started += (_) => OnUseQuickSlot(0);
        inputActions.Character.QuickSlot2.started += (_) => OnUseQuickSlot(1);
        inputActions.Character.QuickSlot3.started += (_) => OnUseQuickSlot(2);

        inputActions.Inventory.DropItemB.started += (_) => OnInventoryDropItemDown(inputActions.Inventory.CursorV2.ReadValue<Vector2>());
        inputActions.Inventory.InventoryB.started += (_) => ChangeState(InputState.Inventory);
    }
    private void Start() {
        ChangeState(InputState.Character);
    }

    static public Vector2 MoveV2N() => Instance.inputActions.Character.MoveV2N.ReadValue<Vector2>();
    static public Vector2 LookV2D() => Instance.inputActions.Character.LookV2D.ReadValue<Vector2>();
    static public bool GetSpringButton() => Instance.inputActions.Character.SprintB.inProgress;

    private void ChangeState(InputState inputState) {
        if (this.inputState == inputState) {
            this.inputState = InputState.Character;
            inputActions.Character.Attack.Enable();
            inputActions.Character.MoveV2N.Enable();
            inputActions.Character.LookV2D.Enable();

            inputActions.Inventory.DropItemB.Disable();

            InventoryUI.Instance.Hide();
            Cursor.lockState = CursorLockMode.Locked;

            return;
        }

        switch (inputState) {
            case InputState.Inventory: {
                this.inputState = InputState.Inventory;
                inputActions.Character.Attack.Disable();
                inputActions.Character.LookV2D.Disable();

                inputActions.Inventory.DropItemB.Enable();

                InventoryUI.Instance.Show();
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

}
