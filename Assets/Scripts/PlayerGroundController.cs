using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundController : MonoBehaviour
{

    Rigidbody rigid;
    public float jumpPower = 15;
    public bool isRunning = false;

    public GameObject standing;
    public GameObject Run;
    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
    }

    private void OnEnable() {
        isRunning = (Input.GetAxis("Horizontal") == 10);
        Run.SetActive(isRunning);
        standing.SetActive(!isRunning);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerState.instance.isGrounded()) {
            if (PlayerState.instance.controlable && Input.GetKeyDown(KeyCode.Z)) {
                Vector3 newVelocity = rigid.velocity;
                newVelocity.y = jumpPower;
                rigid.velocity = newVelocity;
                PlayerState.instance.isJumping = true;
                PlayerState.instance.leaveGround();
            } else if (PlayerState.instance.controlable && Input.GetKeyDown(KeyCode.DownArrow) && PlayerState.instance.isGrounded()) {
                PlayerState.instance.morph();
            } else if (PlayerState.instance.isRunning() != isRunning) {
                isRunning = !isRunning;
                Run.SetActive(isRunning);
                standing.SetActive(!isRunning);
            }
        } else {
            PlayerState.instance.leaveGround();
        }
    }
}
