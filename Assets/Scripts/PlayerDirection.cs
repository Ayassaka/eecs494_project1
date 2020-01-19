using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    bool facing_up = false;
    bool facing_right = true;

    // Update is called once per frame
    
    void Update()
    {
        if (!PlayerState.instance.controlable) return;
        float axis_h = Input.GetAxis("Horizontal");
        if (facing_right) {
            if (axis_h < 0) {
                facing_right = false;
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
        } else {
            if (axis_h > 0) {
                facing_right = true;
                this.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        bool axis_v = Input.GetKey(KeyCode.UpArrow);
        if (facing_up) {
            if (!axis_v) {
                facing_up = false;
                PlayerFireDirection pfd = gameObject.GetComponentInChildren<PlayerFireDirection>();
                if (pfd != null) pfd.setFireDirectionForward();
            }
        } else {
            if (axis_v) {
                facing_up = true;
                PlayerFireDirection pfd = gameObject.GetComponentInChildren<PlayerFireDirection>();
                if (pfd != null) pfd.setFireDirectionUpward();
            }
        }
    }

    public bool isFacingRight() {
        return facing_right;
    }
    public bool isLookingUp() {
        return facing_up;
    }
}
