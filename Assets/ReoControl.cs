using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReoControl : MonoBehaviour
{
    // Start is called before the first frame update

    private Stage stage;  // 0 means inital state; 1 means falling, 2 means rising;
    private Rigidbody rb;
    public LayerMask wallLayer;
    public float horizontalSpeed;
    public float scale = 2;
    enum Stage{init, falling, rising, checkrising, wait};
    private float verticalSpeed;
    private float initposy;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stage = Stage.init;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == Stage.init) {
            float disx = PlayerState.instance.transform.position.x - transform.position.x;
            verticalSpeed = (PlayerState.instance.transform.position.y - transform.position.y - 0.5f) * scale;
            if (disx < 0 && disx > -5) {
                stage = Stage.falling;
                rb.velocity = new Vector3(-horizontalSpeed, verticalSpeed, 0);
                initposy = PlayerState.instance.transform.position.y;
            }
            if (disx > 0 && disx < 5) {
                stage = Stage.falling;
                rb.velocity = new Vector3(horizontalSpeed, verticalSpeed, 0);
                initposy = PlayerState.instance.transform.position.y;
            }
        }
        if (stage == Stage.falling) {
            if (initposy > transform.position.y - 1f) {
                stage = Stage.checkrising;
            } else {
                verticalSpeed = initposy - transform.position.y - 0.5f;
                if (verticalSpeed > 0) {
                    verticalSpeed = 0;
                }
                Vector3 newVec = rb.velocity;
                newVec.y = verticalSpeed;
                rb.velocity = newVec;
            }
        }
        if (stage == Stage.checkrising) {
            if (PlayerState.instance.transform.position.y > transform.position.y + 0.5f) {
                stage = Stage.rising;
            } else {
                verticalSpeed = PlayerState.instance.transform.position.y - transform.position.y;
                if (verticalSpeed > 0) {
                    verticalSpeed = 0;
                }
                Vector3 newVec = rb.velocity;
                newVec.y = verticalSpeed;
                rb.velocity = newVec;
            }
        }
        if (stage == Stage.rising) {
            rb.AddForce(0, 5, 0);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Wall")) {
            if (isLeftWall() || isRightWall()) {
                Vector3 newVec = rb.velocity;
                newVec.x = -newVec.x;
                rb.velocity = newVec;
            }
            if (!isGrounded()) {
                if (isCeil()) {
                    if (stage == Stage.rising) {
                        rb.velocity = Vector3.zero;
                        stage = Stage.wait;
                        StartCoroutine(initwait());
                    }
                }
            } else {
                Vector3 newVec = rb.velocity;
                newVec.y = 0;
                rb.velocity = newVec;
            }
        }
    }

    public bool isGrounded() {
        Collider col = this.GetComponentInChildren<Collider>();
        float offset = 0.5f;
        Ray ray = new Ray(col.bounds.center + Vector3.up * offset, Vector3.down);
        float radius = col.bounds.extents.x - 0.1f;
        float fullDistance = col.bounds.extents.y + 0.01f + offset;
        if (Physics.SphereCast(ray, radius, fullDistance, wallLayer)) {
            return true;
        }
        return false;
    }
    public bool isCeil() {
        Collider col = this.GetComponentInChildren<Collider>();
        float offset = 0.5f;
        Ray ray = new Ray(col.bounds.center - Vector3.up * offset, Vector3.up);
        float radius = col.bounds.extents.x - 0.1f;
        float fullDistance = col.bounds.extents.y + 0.01f + offset;
        if (Physics.SphereCast(ray, radius, fullDistance, wallLayer)) {
            return true;
        }
        return false;
    }
    public bool isLeftWall() {
        Collider col = this.GetComponentInChildren<Collider>();
        float offset = 0.3f;
        Ray ray = new Ray(col.bounds.center - Vector3.left * offset, Vector3.left);
        float radius = col.bounds.extents.x - 0.1f;
        float fullDistance = col.bounds.extents.y + 0.01f + offset;
        if (Physics.SphereCast(ray, radius, fullDistance, wallLayer)) {
            return true;
        }
        return false;
    }
    public bool isRightWall() {
        Collider col = this.GetComponentInChildren<Collider>();
        float offset = 0.3f;
        Ray ray = new Ray(col.bounds.center - Vector3.right * offset, Vector3.right);
        float radius = col.bounds.extents.x - 0.1f;
        float fullDistance = col.bounds.extents.y + 0.01f + offset;
        if (Physics.SphereCast(ray, radius, fullDistance, wallLayer)) {
            return true;
        }
        return false;
    }
    IEnumerator initwait() {

        yield return new WaitForSeconds(0.5f);
        stage = Stage.init;
    }
}
