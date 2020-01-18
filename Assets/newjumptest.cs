using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newjumptest : MonoBehaviour
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
            PlayerState.instance.jump.SetActive(true);
            PlayerState.instance.morphed.SetActive(false);
            PlayerState.instance.standing.SetActive(false);
            PlayerState.instance.isJumping = true;
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
