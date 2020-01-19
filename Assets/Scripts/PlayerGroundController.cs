using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundController : MonoBehaviour
{

    Rigidbody rigid;
    public float jumpPower = 15;
    public bool isRunning;
    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerState.instance.isGrounded()) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                Vector3 newVelocity = rigid.velocity;
                newVelocity.y = jumpPower;
                rigid.velocity = newVelocity;
                PlayerState.instance.leaveGround();
                PlayerState.instance.isJumping = true;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                PlayerState.instance.morph();
            } else if (PlayerState.instance.isRunning() != isRunning) {
                PlayerState.instance.setRunning();
            }
        } else {
            PlayerState.instance.leaveGround();
        }
    }
}
