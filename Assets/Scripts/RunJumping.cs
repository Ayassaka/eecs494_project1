using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunJumping : MonoBehaviour
{
    Rigidbody rigid;
    public float Jumppower;
    private float Movespeed = 4;
    private float currentSpeed;
    private float duration;
    private float durationthereshold = 0.15f;
    void Awake()
    {
        duration = 0;
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
            duration += Time.deltaTime;
            if (duration > durationthereshold) {
                newVelocity.y = Jumppower;
                PlayerState.instance.longpress = 1;
            }
        } else {
            duration = 0;
        }
        
        rigid.velocity = newVelocity;
        //Debug.Log(rigid.velocity.x);
    }
}

