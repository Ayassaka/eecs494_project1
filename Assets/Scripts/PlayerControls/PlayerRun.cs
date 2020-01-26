using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    public float Movespeed = 5;
    public float JumpingMovespeed = 4;
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerState.instance.inLava) {
            JumpingMovespeed = 2;
            Movespeed = 2;
        } else {
            JumpingMovespeed = 4;
            Movespeed = 5;
        }
        if (PlayerState.instance.isControlable()) {
            Debug.Log("enter");
            if (PlayerState.instance.HorizontalInertia && Input.GetAxis("Horizontal") == 0) return;
            Vector3 newVelocity = rigid.velocity;
            if (PlayerState.instance.isJumping) {
                newVelocity.x = Input.GetAxis("Horizontal") * JumpingMovespeed;
            } else {
                newVelocity.x = Input.GetAxis("Horizontal") * Movespeed;
            }
            rigid.velocity = newVelocity;
        }
    }
}
