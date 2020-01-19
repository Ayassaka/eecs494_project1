using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirController : MonoBehaviour
{
    Rigidbody rigid;
    bool isRising = false;
    
    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
    }

    private void OnEnable() {
        isRising = true;
    }
    void Update()
    {
        if (isRising && Input.GetKeyUp(KeyCode.Z)) {
            Vector3 newVelocity = rigid.velocity;
            newVelocity.y = 0;
            rigid.velocity = newVelocity;
        }
        if (PlayerState.instance.isGrounded()) {
            PlayerState.instance.hitGround();
        }
    }

    private void LateUpdate() {
        if (rigid.velocity.y <= 0) isRising = false;
    }
}
