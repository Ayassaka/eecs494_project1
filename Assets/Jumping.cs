using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody rigid;
    public float Jumppower = 10;
    
    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = rigid.velocity;
        if (Input.GetKey(KeyCode.Z) && PlayerState.instance.longpress == 0) {
            PlayerState.instance.longpress = 1;
            newVelocity.y = Jumppower;
        }
        rigid.velocity = newVelocity;
    }
}
