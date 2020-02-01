using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float horizontaldistance;
    private float startposx;
    private float endposx;
    public float speed = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startposx = rb.transform.position.x;
        endposx = startposx + horizontaldistance;
        Debug.Log("enter");
        Debug.Log(rb.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.x > endposx || rb.transform.position.x < startposx) {
            speed = -speed;
        }
        rb.transform.position += new Vector3(speed * 0.01f, 0, 0);
    }
}
