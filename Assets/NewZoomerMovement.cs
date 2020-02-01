using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NewZoomerMovement : MonoBehaviour
{
    // SpriteRenderer sr;
    // public Color stunColor;
        // sr = this.GetComponent<SpriteRenderer>();
    public LayerMask WallLayer;
    public Transform turningPoint;
    public float speed = 5;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = this.transform.right * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(this.transform.position, this.transform.right * speed, .6f, WallLayer)) {
            rb.velocity = new Vector3(-speed, 0, 0);
        }
        if (Physics.Raycast(this.transform.position, -this.transform.right * speed, .6f, WallLayer)) {
            rb.velocity = new Vector3(speed, 0, 0);
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
