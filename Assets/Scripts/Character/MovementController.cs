using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementController : MonoBehaviour {


    [SerializeField] LayerMask collideLayerMack;

    float skinWidth = 0.01f;
    [SerializeField] float maxClimbAngle = 60;
    [Header("Gravity")]
    [SerializeField] float gravityAcceliration;
    [SerializeField] float maxGravityVelocity;
    float gravityVelocity;
    [Header("Jump")]
    [SerializeField] float jumpVelocity;

    CapsuleCollider capsuleCollider;

    private void Awake() {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void FixedUpdate() {
        gravityVelocity = Mathf.Max(gravityVelocity + gravityAcceliration * Time.fixedDeltaTime, maxGravityVelocity);
    }

    public void TryJump() {
        if (IsGrounded()) {
            gravityVelocity = Mathf.Max(0, gravityVelocity);
            gravityVelocity += jumpVelocity;
        }
    }
    public void Move(Vector3 moveVelocity) {
        Vector3 moveVector = CollideAndSlide(transform.position, moveVelocity, false);
        Vector3 gravityMoveVector = Vector3.up * gravityVelocity * Time.fixedDeltaTime;
        moveVector += CollideAndSlide(transform.position + moveVector, gravityMoveVector, true);
        transform.position += moveVector;
    }
    // https://youtu.be/YR6Q7dUz2uk?si=lxioSsyEBnbE1Ea5
    private Vector3 CollideAndSlide(Vector3 position, Vector3 velocity, bool gravityPass, int currentBounce = 0, Vector3 initialVelocity = new Vector3()) {
        if (currentBounce == 0) initialVelocity = velocity;

        int maxBounces = 3;

        if (currentBounce >= maxBounces) return Vector3.zero;

        if (CastSelf(position, velocity, out RaycastHit hit)) {
            Vector3 snapToSurface = velocity.normalized * (hit.distance - skinWidth);
            Vector3 remaining = velocity - snapToSurface;
            float angleOfNormal = Vector3.Angle(Vector3.up, hit.normal);

            if (snapToSurface.magnitude <= skinWidth) snapToSurface = Vector3.zero;

            // nomal ground / slope
            if (angleOfNormal <= maxClimbAngle) {
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

            return snapToSurface + CollideAndSlide(position + snapToSurface, remaining, gravityPass, currentBounce + 1, initialVelocity);
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
        if (CastSelf(transform.position, Vector3.down * 0.01f, out RaycastHit hit)) {
            if (Vector3.Angle(Vector3.up, hit.normal) <= maxClimbAngle) return true;
        }
        return false;
    }
    private bool CastSelf(Vector3 position, Vector3 direction, out RaycastHit hit) {
        // Get Parameters associated with the KCC
        Vector3 center = capsuleCollider.center + position;
        float radius = capsuleCollider.radius;
        float height = capsuleCollider.height;

        // Get top and bottom points of collider
        Vector3 bottom = center + Vector3.down * (height / 2 - radius - skinWidth);
        Vector3 top = center + Vector3.up * (height / 2 - radius - skinWidth);

        // Check what objects this collider will hit when cast with this configuration excluding itself
        IEnumerable<RaycastHit> hits = Physics.CapsuleCastAll(
            top, bottom, radius - skinWidth, direction.normalized, direction.magnitude + skinWidth, collideLayerMack, QueryTriggerInteraction.Ignore)
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
