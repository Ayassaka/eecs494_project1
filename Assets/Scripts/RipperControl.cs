using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipperControl : MonoBehaviour
{
    private Rigidbody rb;
    public LayerMask WallLayer;
    public float speed = 1.5f;
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed, 0, 0);
    }
    /*
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Wall")) {
            Transform obj = GetComponent<Transform>();
            Vector3 newVec = obj.localScale;
            newVec.x = -newVec.x;
            obj.localScale = newVec;
            rb.velocity = -rb.velocity;
        }
    }
    */
    private void Update() {
        if (Physics.Raycast(this.transform.position, Vector3.left * gameObject.transform.localScale.x, .5f, WallLayer)) {
            Transform obj = GetComponent<Transform>();
            Vector3 newVec = obj.localScale;
            newVec.x = -newVec.x;
            obj.localScale = newVec;
            rb.velocity = -rb.velocity;
        }
    }
}
