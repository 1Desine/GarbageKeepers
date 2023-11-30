using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] Transform head;
    [SerializeField] float mouseSensitivity = 0.1f;
    Vector2 lookDireciton;

    MovementController movementController;
    [Header("Movement")]
    [SerializeField] float moveAcceliration;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    Vector3 moveLocalVelocity;


    private void Awake() {
        movementController = GetComponent<MovementController>();
    }
    private void OnEnable() {
        InputManager.OnJumpDown += movementController.TryJump;
    }
    private void OnDisable() {
        InputManager.OnJumpDown -= movementController.TryJump;
    }
    private void Update() {
        HandleLook();
    }
    private void FixedUpdate() {
        Movement();
    }

    private void HandleLook() {
        lookDireciton += InputManager.LookV2D() * mouseSensitivity;
        lookDireciton.y = Mathf.Clamp(lookDireciton.y, -90, 90);
        transform.eulerAngles = Vector3.up * lookDireciton.x;
        head.localEulerAngles = Vector3.right * -lookDireciton.y;
    }
    private void Movement() {
        Vector2 inputDirection = InputManager.MoveV2N();

        Vector3 desiredVelocity = new Vector3(inputDirection.x, 0, inputDirection.y).normalized * walkSpeed;
        if (InputManager.GetSpringButton()) if (desiredVelocity.z > 0) desiredVelocity = desiredVelocity.normalized * runSpeed;

        moveLocalVelocity = Vector3.MoveTowards(moveLocalVelocity, desiredVelocity, moveAcceliration * Time.fixedDeltaTime);
        Vector3 move = (transform.forward * moveLocalVelocity.z + transform.right * moveLocalVelocity.x) * Time.fixedDeltaTime;

        movementController.Move(move);
    }
    public Vector3 GetItemDropPoint() {
        float dropDistance = 1f;
        Vector3 desiredPoint = head.position + head.forward;
        if (Physics.Raycast(head.position, head.forward, out RaycastHit hit, dropDistance)) desiredPoint = head.position + head.forward * (hit.distance - 0.01f);
        return desiredPoint;
    }
    public bool LookingAt(float lookDistance, out RaycastHit hit) {
        IEnumerable<RaycastHit> hits = Physics.RaycastAll(head.position, head.forward, lookDistance, ~0, QueryTriggerInteraction.Ignore)
            .Where(hit => hit.collider.transform != transform);
        bool didHit = hits.Count() > 0;

        // Find the closest objects hit
        float closestDist = didHit ? Enumerable.Min(hits.Select(hit => hit.distance)) : 0;
        IEnumerable<RaycastHit> closestHit = hits.Where(hit => hit.distance == closestDist);

        // Get the first hit object out of the things the player collides with
        hit = closestHit.FirstOrDefault();

        // Return if any objects were hit
        return didHit;
    }

}
