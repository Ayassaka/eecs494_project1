using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public GameObject standing;
    public GameObject morphed;
    bool isMorphed = false;
    void Update()
    {
        if (!isMorphed) {
            if (Input.GetKeyDown(KeyCode.DownArrow) && GetComponentInChildren<PlayerJump>().isGrounded()) {
                standing.SetActive(false);
                morphed.SetActive(true);
                isMorphed = true;
            }
        } else {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)) && (!isMorphedGrounded() || !isMorphedStuck())) {
                standing.SetActive(true);
                morphed.SetActive(false);
                isMorphed = false;
            }
        }
    }

    bool isMorphedGrounded() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.x + 0.05f;
        return Physics.SphereCast(ray, radius, fullDistance);
    }

    bool isMorphedStuck() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.up);
        float radius = col.bounds.extents.x - 0.05f;
        Debug.Log(col.bounds.extents.x);
        float fullDistance = col.bounds.extents.x + 0.05f;
        return Physics.SphereCast(ray, radius, fullDistance);
    }
}