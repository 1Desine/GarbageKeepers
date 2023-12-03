using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] Animator characterAnimator;

    [SerializeField] Transform neck;
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
        neck.localEulerAngles = Vector3.right * -lookDireciton.y;
    }
    private void Movement() {
        Vector2 inputDirection = InputManager.MoveV2N();

        Vector3 desiredVelocity = new Vector3(inputDirection.x, 0, inputDirection.y).normalized * walkSpeed;
        if (InputManager.GetSpringButton()) if (desiredVelocity.z > 0) desiredVelocity = desiredVelocity.normalized * runSpeed;

        moveLocalVelocity = Vector3.MoveTowards(moveLocalVelocity, desiredVelocity, moveAcceliration * Time.fixedDeltaTime);
        Vector3 move = (transform.forward * moveLocalVelocity.z + transform.right * moveLocalVelocity.x) * Time.fixedDeltaTime;

        movementController.Move(move);

        characterAnimator.SetFloat("MoveZ", moveLocalVelocity.z);
        characterAnimator.SetFloat("MoveX", moveLocalVelocity.x);
        characterAnimator.SetFloat("IsRuning", InputManager.GetSpringButton() ? 1 : 0);
    }
    public Vector3 GetItemDropPoint() {
        float dropDistance = 1f;
        Vector3 desiredPoint = neck.position + neck.forward;
        if (Physics.Raycast(neck.position, neck.forward, out RaycastHit hit, dropDistance)) desiredPoint = neck.position + neck.forward * (hit.distance - 0.01f);
        return desiredPoint;
    }
    public bool LookingAt(float reachDistance, out RaycastHit hit) {
        IEnumerable<RaycastHit> hits = Physics.RaycastAll(neck.position, neck.forward, reachDistance, ~0, QueryTriggerInteraction.Ignore)
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
