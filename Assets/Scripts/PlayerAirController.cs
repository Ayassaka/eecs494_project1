using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirController : MonoBehaviour
{
    Rigidbody rigid;
    bool isRising = false;
    float startingHeight;
    private float startingoffset = 0.2f; 

    private float stuckVelocity;
    private bool isWall;
    private float currentSpeed;
    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
    }

    private void OnEnable() {
        startingHeight = rigid.transform.position.y;
        isRising = true;
        isWall = false;
    }
    void Update()
    {
        Vector3 newVelocity = rigid.velocity;
        if (Input.GetAxis("Horizontal") == 0) {
            newVelocity.x = currentSpeed;
        } else {
            newVelocity.x = Input.GetAxis("Horizontal") * 4;
        }
        currentSpeed = newVelocity.x;
        rigid.velocity = newVelocity;
        if (isRising && Input.GetKeyUp(KeyCode.Z)) {
            newVelocity = rigid.velocity;
            newVelocity.y = 0;
            rigid.velocity = newVelocity;
        }
        if (PlayerState.instance.isGrounded()) {
            PlayerState.instance.hitGround();
            PlayerState.instance.isRunjump = false;
        }
        if (rigid.transform.position.y < startingHeight) {
            PlayerState.instance.standing.SetActive(false);
            PlayerState.instance.morphed.SetActive(false);
            PlayerState.instance.jump.SetActive(true);
            PlayerState.instance.Runjump.SetActive(false);
            PlayerState.instance.Run.SetActive(false);
            PlayerState.instance.isRunjump = false;
        }
        /*
        if (isStuckWall() && Input.GetAxis("Horizontal") != 0 && !isWall) {
            stuckVelocity = rigid.velocity.x;
            newVelocity = rigid.velocity;
            newVelocity.x = 0;
            rigid.velocity = newVelocity;
            isWall = true;
        }
        if (!isStuckWall() && isWall) {
            newVelocity = rigid.velocity;
            newVelocity.x = stuckVelocity;
            rigid.velocity = newVelocity;
            isWall = false;
        }*/
    }

    private void LateUpdate() {
        if (rigid.velocity.y <= 0) isRising = false;
    }
    private bool isStuckWall() {
        Collider col = this.GetComponent<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.left);
        if (Physics.Raycast(col.bounds.center, Vector3.left, col.bounds.extents.x, PlayerState.instance.wallLayer)) {
            return true;
        }
        return false;
    }
}
