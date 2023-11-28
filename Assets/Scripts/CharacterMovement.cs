using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngineInternal;
using static UnityEditor.PlayerSettings;

public class CharacterMovement : MonoBehaviour {


    [SerializeField] Transform head;

    [SerializeField] float mouseSensitivity = 0.1f;
    [Header("Movement")]
    [SerializeField] float moveAcceliration;
    [SerializeField] float maxWalkSpeed;
    [SerializeField] float maxRunForwandSpeed;
    [SerializeField] float maxRunDiagnalSpeed;
    Vector3 moveVelocity;
    [Header("Gravity")]
    [SerializeField] float gravityAcceliration;
    [SerializeField] float maxGravityVelocity;
    float gravityVelocity;
    [Header("Jump")]
    [SerializeField] float jumpTime;
    [SerializeField] float jumpSpeed;
    float lastJumpTime;

    Vector2 lookDireciton;

    CapsuleCollider capsuleCollider;
    [SerializeField] Transform debugCapsule;


    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;


        capsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void Update() {
        HandleLook();
    }
    private void FixedUpdate() {
        Movement();
        Gravity();
    }
    private void HandleLook() {
        lookDireciton += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;
        lookDireciton.y = Mathf.Clamp(lookDireciton.y, -90, 90);
        transform.eulerAngles = Vector3.up * lookDireciton.x;
        head.localEulerAngles = Vector3.right * -lookDireciton.y;
    }
    private void Movement() {
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 desiredVelocity = new Vector3(inputDirection.x, 0, inputDirection.y).normalized * maxWalkSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) { // if sprint
            if (desiredVelocity.z > 0) {
                if (desiredVelocity.x != 0) desiredVelocity.z = maxRunDiagnalSpeed;
                else desiredVelocity.z = maxRunForwandSpeed;
            }
        }
        moveVelocity = Vector3.MoveTowards(moveVelocity, desiredVelocity, moveAcceliration * Time.fixedDeltaTime);
        Vector3 remaining = (transform.forward * moveVelocity.z + transform.right * moveVelocity.x) * Time.fixedDeltaTime;

        debugCapsule.position = transform.position + remaining;


        transform.position += CollideAndSlide(remaining, transform.position, false);
    }
    private void Gravity() {
        gravityVelocity = Mathf.Max(gravityVelocity + gravityAcceliration * Time.fixedDeltaTime, maxGravityVelocity);
        Vector3 remaining = Vector3.up * gravityVelocity * Time.fixedDeltaTime;

        transform.position += CollideAndSlide(remaining, transform.position, true);
    }
    // https://youtu.be/YR6Q7dUz2uk?si=lxioSsyEBnbE1Ea5
    private Vector3 CollideAndSlide(Vector3 velocity, Vector3 position, bool gravityPass, int depth = 0, Vector3 initialVelocity = new Vector3()) {
        if (depth == 0) initialVelocity = velocity;

        int maxBounces = 3;
        float skinWidth = 0.01f;
        float maxNormalAngleToClimb = 60;

        Bounds bounds = capsuleCollider.bounds;
        bounds.Expand(-2 * skinWidth);

        if (depth >= maxBounces) return Vector3.zero;

        float dist = velocity.magnitude + skinWidth;

        if (CastSelf(velocity.normalized * dist, skinWidth, out RaycastHit hit)) {
            Vector3 snapToSurface = velocity.normalized * (hit.distance - skinWidth);
            Vector3 remaining = velocity - snapToSurface;
            float normalAngle = Vector3.Angle(Vector3.up, hit.normal);

            if (snapToSurface.magnitude <= skinWidth) snapToSurface = Vector3.zero;

            // nomal ground / slope
            if (normalAngle <= maxNormalAngleToClimb) {
                if (gravityPass) return snapToSurface;

                remaining = ProjectAndScale(remaining, hit.normal);
            }
            // wall or steep slope
            else {
                float scale = 1 - Vector3.Dot(
                    new Vector3(hit.normal.x, 0, hit.normal.z).normalized,
                    -new Vector3(initialVelocity.x, 0, initialVelocity.z).normalized
                );

                if (IsGrounded() && !gravityPass) {
                    remaining = ProjectAndScale(
                        new Vector3(remaining.x, 0, remaining.z),
                        new Vector3(hit.normal.x, 0, hit.normal.z)
                    );
                    remaining *= scale;
                }
                else remaining = ProjectAndScale(remaining, hit.normal) * scale;
            }

            return snapToSurface + CollideAndSlide(remaining, position + snapToSurface, gravityPass, depth + 1, initialVelocity);
        }

        return velocity;
    }
    private Vector3 ProjectAndScale(Vector3 vector, Vector3 plane) {
        float mag = vector.magnitude;
        vector = Vector3.ProjectOnPlane(vector, plane).normalized;
        vector *= mag;

        return vector;
    }
    private bool IsGrounded() {
        return CastSelf(Vector3.down, 0.01f, out RaycastHit hit);
    }
    public bool CastSelf(Vector3 direction, float skinWidth, out RaycastHit hit) {
        // Get Parameters associated with the KCC
        Vector3 center = capsuleCollider.center + transform.position;
        float radius = capsuleCollider.radius;
        float height = capsuleCollider.height;

        // Get top and bottom points of collider
        Vector3 bottom = center + Vector3.down * (height / 2 - radius) + Vector3.up * skinWidth;
        Vector3 top = center + Vector3.up * (height / 2 - radius) + Vector3.down * skinWidth;

        // Check what objects this collider will hit when cast with this configuration excluding itself
        IEnumerable<RaycastHit> hits = Physics.CapsuleCastAll(
            top, bottom, radius - skinWidth, direction.normalized, direction.magnitude, ~0, QueryTriggerInteraction.Ignore)
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
