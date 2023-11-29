using System;
using UnityEngine;

public class InputManager : MonoBehaviour {
    static public InputManager Instance { get; private set; }


    private InputActions inputActions;

    static public Action OnJumpDown = () => { };
    static public Action OnAttackDown = () => { };
    static public Action<Vector2> OnInventoryDropItemDown = (_) => { };

    private InputState inputState;
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

        inputActions.Inventory.DropItemB.started += (_) => OnInventoryDropItemDown(inputActions.Inventory.CursorV2.ReadValue<Vector2>());
        inputActions.Inventory.InventoryB.started += (_) => ChangeState(InputState.Inventory);


        ChangeState(InputState.Character);
    }

    static public Vector2 MoveV2N() => Instance.inputActions.Character.MoveV2N.ReadValue<Vector2>();
    static public Vector2 LookV2D() => Instance.inputActions.Character.LookV2D.ReadValue<Vector2>();


    private void ChangeState(InputState inputState) {
        if (this.inputState == inputState) {
            // Enter state Character
            Debug.Log("Enter InputState.Character");
            this.inputState = InputState.Character;
            inputActions.Character.Attack.Enable();
            inputActions.Character.MoveV2N.Enable();
            inputActions.Character.LookV2D.Enable();

            inputActions.Inventory.DropItemB.Disable();

            return;
        }

        switch (inputState) {
            case InputState.Inventory: {
                // Enter Inventory
                Debug.Log("Enter InputState.Inventory");
                this.inputState = InputState.Inventory;
                inputActions.Character.Attack.Disable();
                inputActions.Character.LookV2D.Disable();

                inputActions.Inventory.DropItemB.Enable();

                break;
            }
            case InputState.Settings: {
                // Enter Settings
                Debug.Log("Enter InputState.Settings");
                this.inputState = InputState.Settings;
                inputActions.Character.Attack.Disable();
                inputActions.Character.MoveV2N.Disable();

                break;
            }
        }
    }

}
