using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    public float Movespeed = 5;
    public float Jumppower = 5;
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = rigid.velocity;
        newVelocity.x = Input.GetAxis("Horizontal") * Movespeed;
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded()) {
            newVelocity.y = Jumppower;
        }
        rigid.velocity = newVelocity;
        
    }
    bool isGrounded() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance)) {
            return true;
        }
        return false;
    }
}
