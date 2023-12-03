using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField] Animator characterAnimator;

    [SerializeField] Transform neck;
    [SerializeField] float mouseSensitivity = 0.1f;
    Vector2 lookVector;

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
    private void Start() {
        PlaceCharacterAtSpawnPosition();
        SceneManager.sceneLoaded += (Scene, LoadSceneMode) => PlaceCharacterAtSpawnPosition();
    }
    private void Update() {
        HandleLook();
    }
    private void FixedUpdate() {
        Movement();
    }


    private void PlaceCharacterAtSpawnPosition() {
        List<Transform> spawnTransforms = ScenePropperties.GetSpawnPositions();
        int positionIndex = Random.Range(0, spawnTransforms.Count);

        transform.position = spawnTransforms[positionIndex].position;
        lookVector = new Vector2(spawnTransforms[positionIndex].eulerAngles.x, 0);

        Debug.Log("deeee");
    }

    private void HandleLook() {
        lookVector += InputManager.LookV2D() * mouseSensitivity;
        lookVector.y = Mathf.Clamp(lookVector.y, -90, 90);
        transform.eulerAngles = Vector3.up * lookVector.x;
        neck.localEulerAngles = Vector3.right * -lookVector.y;
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
    public void GetItemDropPositioning(out Vector3 position, out Quaternion rotation) {
        float dropDistance = 1f;
        Vector3 desiredPosition = neck.position + neck.forward;
        Quaternion desiredRotation = Quaternion.identity;
        if (Physics.Raycast(neck.position, neck.forward, out RaycastHit hit, dropDistance)) {
            desiredPosition = neck.position + neck.forward * (hit.distance - 0.01f);
            desiredRotation = Quaternion.LookRotation(hit.normal);
        }
        else if (Physics.Raycast(desiredPosition, Vector3.down, out RaycastHit hit2)) {
            desiredPosition = desiredPosition + Vector3.down * (hit2.distance - 0.1f);
            desiredRotation = Quaternion.LookRotation(hit.normal);
        }

        position = desiredPosition;
        rotation = desiredRotation;
    }

}
