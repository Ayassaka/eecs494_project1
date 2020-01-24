using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunable : MonoBehaviour
{
    int stunned = 0;
    SpriteRenderer sr;
    Color color_temp;
    Rigidbody rb;
    RigidbodyConstraints rbc_temp;
    Vector3 velocity_temp;
    public Color stunColor;

    void Start()
    {        
        sr = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody>();
    }

    public IEnumerator stun(float time) {
        if (stunned == 0) {
            rbc_temp = rb.constraints;
            velocity_temp = rb.velocity;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            color_temp = sr.color;
            sr.color = stunColor;
        }
        stunned++;
        yield return new WaitForSeconds(time);
        stunned--;
        if (stunned == 0) {
            rb.constraints = rbc_temp;
            rb.velocity = velocity_temp;
            sr.color = color_temp;
        }
    }
}
