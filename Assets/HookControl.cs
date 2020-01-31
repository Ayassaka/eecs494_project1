using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookControl : MonoBehaviour
{
    public float speed = 20f;
    public float length = 5f;
    public LayerMask hookable;
    public GameObject playerAnchor;
    Rigidbody rb;
    Rigidbody prb;
    Rigidbody parb;
    ConfigurableJoint cj;
    bool will_hit = false;
    Vector3 hit_pos;
    bool isSwinging = true;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        prb = PlayerState.instance.gameObject.GetComponent<Rigidbody>();
        parb = playerAnchor.GetComponent<Rigidbody>();
        cj = playerAnchor.gameObject.GetComponent<ConfigurableJoint>();
        hit_pos = new Vector3(0, float.PositiveInfinity, 0);
    }
    private void OnEnable() {
        parb.isKinematic = true;
        rb.isKinematic = false;
        rb.transform.position = prb.position;
        Vector3 direction = new Vector3(
            PlayerState.instance.gameObject.transform.localScale.x,
            1, 0).normalized;
        rb.velocity = direction * speed;
        RaycastHit hitInfo;
        will_hit = Physics.Raycast(transform.position, direction, out hitInfo, length, hookable);
        if (will_hit) {
            hit_pos = hitInfo.point;
        } else {
            hit_pos = transform.position + direction * length;
        }
        isSwinging = false;
    }
    // Start is called before the first frame update
    private void start_swing() {
        Debug.Log("Start Swing!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        transform.position = hit_pos;
        rb.transform.position = hit_pos;
        Debug.Log("Hook position: " + transform.position);
        Debug.Log("Player position: " + PlayerState.instance.transform.position);
        Debug.Log("Anchor position: " + playerAnchor.transform.position);
        
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        parb.isKinematic = false;
        isSwinging = true;
        
        playerAnchor.transform.position = PlayerState.instance.transform.position;
        parb.velocity = prb.velocity;
        cj.autoConfigureConnectedAnchor = false;
        cj.connectedBody = rb;
        cj.anchor = hit_pos - PlayerState.instance.gameObject.transform.position;
        cj.connectedAnchor = Vector3.zero;

        Debug.Log("Anchor: " + cj.anchor);
        cj.xMotion = ConfigurableJointMotion.Locked;
        cj.yMotion = ConfigurableJointMotion.Locked;
        cj.zMotion = ConfigurableJointMotion.Locked;
        // StartCoroutine(lock_on());
        prb.isKinematic = true;
    }

    // IEnumerator lock_on() {
    //     yield return new WaitForFixedUpdate();
    //     cj.autoConfigureConnectedAnchor = true;
    //     cj.connectedBody = rb;
    //     cj.anchor = hit_pos - PlayerState.instance.gameObject.transform.position;
    // }

    private void FixedUpdate() {
        Debug.Log("Physics Update.");
    }

    private void OnTriggerEnter(Collider other) {
        if (!isSwinging && !other.CompareTag("Player")) {
            Debug.Log(">>>Starting from trigger enter...");
            start_swing();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update.");
        if (Input.GetKeyUp(KeyCode.Z)) {
            gameObject.SetActive(false);
        }
        if (!isSwinging) {
            if (transform.position.y > hit_pos.y) {
                if (will_hit) {
                    Debug.Log(">>>Starting from raycast...");
                    start_swing();
                } else {
                    gameObject.SetActive(false);
                }
            }
        }
        if (isSwinging) {
            Debug.Log("Swing Update!");
            Debug.Log("Hook position: " + transform.position);
            Debug.Log("Player position: " + PlayerState.instance.transform.position);
            Debug.Log("Anchor position: " + playerAnchor.transform.position);
            Debug.Log("Anchor: " + cj.anchor);
            PlayerState.instance.transform.position = playerAnchor.transform.position;
        }
    }

    // private void FixedUpdate() {
    //     if (isSwinging) {

    //     }
    // }

    private void OnDisable() {
        prb.isKinematic = false;
        prb.velocity = parb.velocity;
        parb.isKinematic = true;
        cj.xMotion = ConfigurableJointMotion.Free;
        cj.yMotion = ConfigurableJointMotion.Free;
        cj.zMotion = ConfigurableJointMotion.Free;
    }
}

// TODO : state change (take damage, hit ground etc.)
// TODO : physics bug