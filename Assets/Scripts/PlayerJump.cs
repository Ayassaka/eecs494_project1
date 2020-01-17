using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    Rigidbody rigid;
    public float Jumppower = 5;
    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = rigid.velocity;
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded()) {
            newVelocity.y = Jumppower;
        }
        rigid.velocity = newVelocity;
        
    }
    bool isGrounded() {
        Collider col = this.GetComponent<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance)) {
            return true;
        }
        return false;
    }
}
