//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""e80f0edb-90c9-4a3f-829a-a3bd8d7c8888"",
            ""actions"": [
                {
                    ""name"": ""MoveV2N"",
                    ""type"": ""Value"",
                    ""id"": ""218c3b0a-ef9d-48de-aa30-390406588500"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookV2D"",
                    ""type"": ""Value"",
                    ""id"": ""683c5c73-a265-4025-87c6-99ad9bf98289"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""024f0ddd-9c2b-4256-bea6-0119adb1a115"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5d813cdc-0005-4004-b43b-6aa304351a6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MainActionB"",
                    ""type"": ""Button"",
                    ""id"": ""297a4b5e-f182-43c8-9c23-cf54328437c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SprintB"",
                    ""type"": ""Button"",
                    ""id"": ""82d603c2-ccda-4ad8-8409-f6f6bc5051f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot1"",
                    ""type"": ""Button"",
                    ""id"": ""7886c8bd-7516-4d04-995d-b70adc8fb68f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot2"",
                    ""type"": ""Button"",
                    ""id"": ""e13063f0-ce46-45fc-9908-e1ba55ca56db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot3"",
                    ""type"": ""Button"",
                    ""id"": ""9b1e9bf4-b796-4da0-849c-ab039ed1e79a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""33699ba6-97b4-4f91-885c-4a9113d39453"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveV2N"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c0101ae4-62bf-40a3-8570-99273c8671a9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveV2N"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d00ccc64-275c-4d9e-93cf-d8920ec23597"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveV2N"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bbecc7a0-a027-46c7-9861-a983133b0f6b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveV2N"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1b7c26d9-44b7-4bb4-b9f5-10721dfc75ec"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveV2N"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e840c3bf-10c9-477e-8eed-3300990f99af"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookV2D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d0f49dc-ffa5-4248-a257-e9d7bbcd09fe"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""220d4849-73f9-4cb3-a462-5224aeadbcc2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29b56791-e8d6-45cf-a94e-bf638f6b66c2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainActionB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b6e98f0-fcc3-4759-92d1-6b1e6684ca77"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e7a7a98-44d1-4ac8-9033-909a1e2d5875"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f7194a1-69bb-4ec3-a036-7e25f92f14c0"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbc6eac7-d826-4b0f-bd94-3947784b915d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""4fbc5053-02b4-4892-9bf8-58b0f0225c2a"",
            ""actions"": [
                {
                    ""name"": ""CursorV2"",
                    ""type"": ""Value"",
                    ""id"": ""7b00a60f-d810-4cf3-906e-c98d365d890b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DropItemB"",
                    ""type"": ""Button"",
                    ""id"": ""1f961ca5-945e-4b02-8001-520d6dc26ec0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InventoryB"",
                    ""type"": ""Button"",
                    ""id"": ""6f3af759-4b1b-43c0-879e-763f4759b230"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""439e7406-8313-4542-b97f-73eae0feece6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorV2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1ead43a-8ec5-42df-a8af-03eaffff7f0e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropItemB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35afdc0a-bc3f-460d-95b6-685353a474b3"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_MoveV2N = m_Character.FindAction("MoveV2N", throwIfNotFound: true);
        m_Character_LookV2D = m_Character.FindAction("LookV2D", throwIfNotFound: true);
        m_Character_Jump = m_Character.FindAction("Jump", throwIfNotFound: true);
        m_Character_Attack = m_Character.FindAction("Attack", throwIfNotFound: true);
        m_Character_MainActionB = m_Character.FindAction("MainActionB", throwIfNotFound: true);
        m_Character_SprintB = m_Character.FindAction("SprintB", throwIfNotFound: true);
        m_Character_QuickSlot1 = m_Character.FindAction("QuickSlot1", throwIfNotFound: true);
        m_Character_QuickSlot2 = m_Character.FindAction("QuickSlot2", throwIfNotFound: true);
        m_Character_QuickSlot3 = m_Character.FindAction("QuickSlot3", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_CursorV2 = m_Inventory.FindAction("CursorV2", throwIfNotFound: true);
        m_Inventory_DropItemB = m_Inventory.FindAction("DropItemB", throwIfNotFound: true);
        m_Inventory_InventoryB = m_Inventory.FindAction("InventoryB", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Character
    private readonly InputActionMap m_Character;
    private List<ICharacterActions> m_CharacterActionsCallbackInterfaces = new List<ICharacterActions>();
    private readonly InputAction m_Character_MoveV2N;
    private readonly InputAction m_Character_LookV2D;
    private readonly InputAction m_Character_Jump;
    private readonly InputAction m_Character_Attack;
    private readonly InputAction m_Character_MainActionB;
    private readonly InputAction m_Character_SprintB;
    private readonly InputAction m_Character_QuickSlot1;
    private readonly InputAction m_Character_QuickSlot2;
    private readonly InputAction m_Character_QuickSlot3;
    public struct CharacterActions
    {
        private @InputActions m_Wrapper;
        public CharacterActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveV2N => m_Wrapper.m_Character_MoveV2N;
        public InputAction @LookV2D => m_Wrapper.m_Character_LookV2D;
        public InputAction @Jump => m_Wrapper.m_Character_Jump;
        public InputAction @Attack => m_Wrapper.m_Character_Attack;
        public InputAction @MainActionB => m_Wrapper.m_Character_MainActionB;
        public InputAction @SprintB => m_Wrapper.m_Character_SprintB;
        public InputAction @QuickSlot1 => m_Wrapper.m_Character_QuickSlot1;
        public InputAction @QuickSlot2 => m_Wrapper.m_Character_QuickSlot2;
        public InputAction @QuickSlot3 => m_Wrapper.m_Character_QuickSlot3;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Add(instance);
            @MoveV2N.started += instance.OnMoveV2N;
            @MoveV2N.performed += instance.OnMoveV2N;
            @MoveV2N.canceled += instance.OnMoveV2N;
            @LookV2D.started += instance.OnLookV2D;
            @LookV2D.performed += instance.OnLookV2D;
            @LookV2D.canceled += instance.OnLookV2D;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @MainActionB.started += instance.OnMainActionB;
            @MainActionB.performed += instance.OnMainActionB;
            @MainActionB.canceled += instance.OnMainActionB;
            @SprintB.started += instance.OnSprintB;
            @SprintB.performed += instance.OnSprintB;
            @SprintB.canceled += instance.OnSprintB;
            @QuickSlot1.started += instance.OnQuickSlot1;
            @QuickSlot1.performed += instance.OnQuickSlot1;
            @QuickSlot1.canceled += instance.OnQuickSlot1;
            @QuickSlot2.started += instance.OnQuickSlot2;
            @QuickSlot2.performed += instance.OnQuickSlot2;
            @QuickSlot2.canceled += instance.OnQuickSlot2;
            @QuickSlot3.started += instance.OnQuickSlot3;
            @QuickSlot3.performed += instance.OnQuickSlot3;
            @QuickSlot3.canceled += instance.OnQuickSlot3;
        }

        private void UnregisterCallbacks(ICharacterActions instance)
        {
            @MoveV2N.started -= instance.OnMoveV2N;
            @MoveV2N.performed -= instance.OnMoveV2N;
            @MoveV2N.canceled -= instance.OnMoveV2N;
            @LookV2D.started -= instance.OnLookV2D;
            @LookV2D.performed -= instance.OnLookV2D;
            @LookV2D.canceled -= instance.OnLookV2D;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @MainActionB.started -= instance.OnMainActionB;
            @MainActionB.performed -= instance.OnMainActionB;
            @MainActionB.canceled -= instance.OnMainActionB;
            @SprintB.started -= instance.OnSprintB;
            @SprintB.performed -= instance.OnSprintB;
            @SprintB.canceled -= instance.OnSprintB;
            @QuickSlot1.started -= instance.OnQuickSlot1;
            @QuickSlot1.performed -= instance.OnQuickSlot1;
            @QuickSlot1.canceled -= instance.OnQuickSlot1;
            @QuickSlot2.started -= instance.OnQuickSlot2;
            @QuickSlot2.performed -= instance.OnQuickSlot2;
            @QuickSlot2.canceled -= instance.OnQuickSlot2;
            @QuickSlot3.started -= instance.OnQuickSlot3;
            @QuickSlot3.performed -= instance.OnQuickSlot3;
            @QuickSlot3.canceled -= instance.OnQuickSlot3;
        }

        public void RemoveCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActions @Character => new CharacterActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private List<IInventoryActions> m_InventoryActionsCallbackInterfaces = new List<IInventoryActions>();
    private readonly InputAction m_Inventory_CursorV2;
    private readonly InputAction m_Inventory_DropItemB;
    private readonly InputAction m_Inventory_InventoryB;
    public struct InventoryActions
    {
        private @InputActions m_Wrapper;
        public InventoryActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @CursorV2 => m_Wrapper.m_Inventory_CursorV2;
        public InputAction @DropItemB => m_Wrapper.m_Inventory_DropItemB;
        public InputAction @InventoryB => m_Wrapper.m_Inventory_InventoryB;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void AddCallbacks(IInventoryActions instance)
        {
            if (instance == null || m_Wrapper.m_InventoryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Add(instance);
            @CursorV2.started += instance.OnCursorV2;
            @CursorV2.performed += instance.OnCursorV2;
            @CursorV2.canceled += instance.OnCursorV2;
            @DropItemB.started += instance.OnDropItemB;
            @DropItemB.performed += instance.OnDropItemB;
            @DropItemB.canceled += instance.OnDropItemB;
            @InventoryB.started += instance.OnInventoryB;
            @InventoryB.performed += instance.OnInventoryB;
            @InventoryB.canceled += instance.OnInventoryB;
        }

        private void UnregisterCallbacks(IInventoryActions instance)
        {
            @CursorV2.started -= instance.OnCursorV2;
            @CursorV2.performed -= instance.OnCursorV2;
            @CursorV2.canceled -= instance.OnCursorV2;
            @DropItemB.started -= instance.OnDropItemB;
            @DropItemB.performed -= instance.OnDropItemB;
            @DropItemB.canceled -= instance.OnDropItemB;
            @InventoryB.started -= instance.OnInventoryB;
            @InventoryB.performed -= instance.OnInventoryB;
            @InventoryB.canceled -= instance.OnInventoryB;
        }

        public void RemoveCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInventoryActions instance)
        {
            foreach (var item in m_Wrapper.m_InventoryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    public interface ICharacterActions
    {
        void OnMoveV2N(InputAction.CallbackContext context);
        void OnLookV2D(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMainActionB(InputAction.CallbackContext context);
        void OnSprintB(InputAction.CallbackContext context);
        void OnQuickSlot1(InputAction.CallbackContext context);
        void OnQuickSlot2(InputAction.CallbackContext context);
        void OnQuickSlot3(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnCursorV2(InputAction.CallbackContext context);
        void OnDropItemB(InputAction.CallbackContext context);
        void OnInventoryB(InputAction.CallbackContext context);
    }
}
