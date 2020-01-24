using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZoomerMovement : MonoBehaviour
{
    // SpriteRenderer sr;
    // public Color stunColor;
        // sr = this.GetComponent<SpriteRenderer>();
    public LayerMask WallLayer;
    public Transform turningPoint;
    public float speed = 5;
    Rigidbody rb;
    bool turning = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = this.transform.right * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (turning) {
            if(Physics.Raycast(turningPoint.position, turningPoint.up, .2f, WallLayer)) {
                turning = false;
            }
        } else if (!Physics.Raycast(turningPoint.position, turningPoint.up, .2f, WallLayer)) {
            rb.transform.Rotate(-this.transform.forward * speed, 90f);
            rb.velocity = this.transform.right * speed;
            turning = true;
        }
        if (Physics.Raycast(this.transform.position, this.transform.right * speed, .6f, WallLayer)) {
            rb.transform.Rotate(this.transform.forward * speed, 90f);
            rb.transform.Translate(Vector3.down * .125f);
            rb.velocity = this.transform.right * speed;
        }
    }

    // public IEnumerator stun(float time) {
    //     rb.velocity = Vector3.zero;
    //     sr.color = stunColor;
    //     yield return new WaitForSeconds(time);
    //     rb.velocity = this.transform.right * speed;
    //     sr.color = Color.white;
    // }
}
