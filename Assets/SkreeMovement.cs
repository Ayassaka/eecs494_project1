using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkreeMovement : MonoBehaviour
{
    // Update is called once per frame
    private float velocityVertical = -5;
    public LayerMask wallLayer;
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if (!isGrounded()) {
            if (detectplayer()) {
                Vector3 newVelocity = rb.velocity;
                newVelocity.y = -5;
                newVelocity.x = (PlayerState.instance.transform.position.x - transform.position.x)/2;
                rb.velocity = newVelocity;
            }
        } else {
            rb.velocity = Vector3.zero;
        }
    }

    bool detectplayer() {
        if (PlayerState.instance.transform.position.x > transform.position.x + 5f) {
            return true;
        }
        if (PlayerState.instance.transform.position.x < transform.position.x - 5f) {
            return false;
        }
        if (PlayerState.instance.transform.position.y < transform.position.y - 20f) {
            return false;
        }
        if (PlayerState.instance.transform.position.y > transform.position.y + 20f) {
            return false;
        }
        return true;
    }
    public bool isGrounded() {
        Collider col = this.GetComponent<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance, wallLayer)) {
            return true;
        }
        return false;
    }
}
