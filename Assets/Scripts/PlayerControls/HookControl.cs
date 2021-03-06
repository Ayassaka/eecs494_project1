﻿using System.Collections;
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
    private Collider cl;
    Vector3 connectedOffset;
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
        transform.position = prb.position;
        rb.position = prb.position;

        Vector3 direction = new Vector3(
            PlayerState.instance.gameObject.transform.localScale.x,
            1, 0).normalized;
        rb.velocity = direction * speed;

        RaycastHit hitInfo;
        will_hit = Physics.Raycast(rb.position, direction, out hitInfo, length, hookable);
        if (will_hit) {
            hit_pos = hitInfo.point;
            cl = hitInfo.collider;
        } else {
            hit_pos = rb.position + direction * length;
        }
        isSwinging = false;
    }
    private void start_swing() {
        rb.position = hit_pos;
        transform.position = hit_pos;
        rb.isKinematic = true;
        parb.isKinematic = false;
        parb.position = prb.position;
        parb.velocity = prb.velocity;
        prb.isKinematic = true;
        cj.anchor = - (Quaternion.Inverse(parb.rotation) * (parb.position - rb.position));
        cj.connectedAnchor = rb.position;
        connectedOffset = cl.transform.position - rb.position;

        cj.xMotion = ConfigurableJointMotion.Locked;
        cj.yMotion = ConfigurableJointMotion.Locked;
        cj.zMotion = ConfigurableJointMotion.Locked;
        
        isSwinging = true;
    }

    private void Swinging() {
        // cj.anchor = - (Quaternion.Inverse(parb.rotation) * (parb.position - rb.position));
        cj.connectedAnchor = rb.position;
    }
    void Update()
    {
        // Debug.Log("Update.");
        
        if (isSwinging) {
            Vector3 curroffset = cl.transform.position - (rb.position + connectedOffset);
            rb.position = cl.transform.position - connectedOffset;
            parb.position += curroffset;
            Swinging();
            prb.position = parb.position;
        } else {
            if (rb.position.y > hit_pos.y) {
                if (will_hit) {
                    start_swing();
                    if (cl.gameObject.CompareTag("transport")) {
                        cl.gameObject.GetComponent<TransportControl>().startMoving();
                    }
                } else {
                    gameObject.SetActive(false);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Z)) {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable() {
        if (isSwinging) {
            prb.isKinematic = false;
            prb.velocity = parb.velocity;
            parb.isKinematic = true;
            cj.xMotion = ConfigurableJointMotion.Free;
            cj.yMotion = ConfigurableJointMotion.Free;
            cj.zMotion = ConfigurableJointMotion.Free;
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(parb.position, 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(cj.connectedAnchor, 1f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(parb.transform.TransformPoint(cj.anchor), .8f);
    }
}


// TODO : state change (take damage, hit ground etc.)
// TODO : physics bug