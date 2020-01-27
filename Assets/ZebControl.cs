using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebControl : MonoBehaviour
{
    private bool horizontalmove = false;
    public float horizontalSpeed;
    private bool faceleft = true;
    private Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 4, 0);
        float disx = PlayerState.instance.transform.position.x - transform.position.x;
        if (disx > 0) {
            Vector3 newScale = this.transform.localScale;
            newScale.x = -newScale.x;
            this.transform.localScale = newScale;
            faceleft = false;
        }
     }
    private void Update() {
        
        if (PlayerState.instance.transform.position.y < transform.position.y && !horizontalmove) {
            horizontalmove = true;
            StartCoroutine(horizontalMove());
        }
    }
    IEnumerator horizontalMove() {
        if (faceleft) {
            rb.velocity = new Vector3(-horizontalSpeed, 0, 0);
        } else {
            rb.velocity = new Vector3(horizontalSpeed, 0, 0);
        }
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
