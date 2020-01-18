using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunJumping : MonoBehaviour
{
    Rigidbody rigid;
    public float Jumppower = 10;
    private float Movespeed = 3;
    private float currentSpeed;
    void Awake()
    {

        rigid = this.GetComponentInParent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = rigid.velocity;
        if (Input.GetAxis("Horizontal") == 0) {
            newVelocity.x = currentSpeed;
        } else {
            newVelocity.x = Input.GetAxis("Horizontal") * Movespeed;
        }
        currentSpeed = newVelocity.x;
        if (Input.GetKey(KeyCode.Z) && PlayerState.instance.longpress == 0) {
            PlayerState.instance.longpress = 1;
            newVelocity.y = Jumppower;
        }
        
        rigid.velocity = newVelocity;
        //Debug.Log(rigid.velocity.x);
    }
}

