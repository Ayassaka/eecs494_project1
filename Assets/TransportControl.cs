using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportControl : MonoBehaviour
{
    // Start is called before the first frame update
    private enum Stage{init, moving, stop, back};
    private Stage transport ;

    public float horizontalDis;
    public float verticalDis;
    public float horizontalVelocity;
    public float verticalVelocity;
    private Vector3 initalPos;
    private Rigidbody rb;
    private bool stopsign;
    private float scale = 0.01f;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        stopsign = false;
        transport = Stage.init;
    }
    // Update is called once per frame
    void Update()
    {
        if (transport == Stage.init) {
            initalPos = transform.position;
        }
        if (transport == Stage.moving) {
            if (transform.position.y > initalPos.y + verticalDis) {
                transform.position += new Vector3(horizontalVelocity, 0, 0) * scale;
            } else {
                transform.position += new Vector3(0, verticalVelocity, 0) * scale;
            }
            if (transform.position.x > initalPos.x + horizontalDis) {
                transport = Stage.stop;
            }
        }
        if (transport == Stage.stop && !stopsign) {
            rb.velocity = Vector3.zero;
            stopsign = true;
            StartCoroutine(Stop());
        }
        if (transport == Stage.back) {
            
            if (transform.position.x < initalPos.x) {
                transform.position += new Vector3(0, -verticalVelocity, 0) * 2 * scale;
            } else {
                transform.position += new Vector3(-horizontalVelocity, 0, 0) * 2 * scale;
            }
            if (transform.position.y < initalPos.y) {
                transport = Stage.init;
            }
        }
    }

    public void startMoving() {

        transport = Stage.moving;
    }
    IEnumerator Stop() {
        yield return new WaitForSeconds(1f);
        stopsign = false;
        transport = Stage.back;
    }
}
