using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody rigid;
    public float Jumppower;
    private float duration;
    private float durationthereshold = 0.15f;
    
    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = rigid.velocity;
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
    }
}
