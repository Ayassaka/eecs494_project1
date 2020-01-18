﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite spriteLookingForward;
    public Sprite spriteLookingUpward;

    bool facing_up = false;
    bool facing_right = true;

    // Update is called once per frame
    void Update()
    {
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
                spriteRenderer.sprite = spriteLookingForward;
            }
        } else {
            if (axis_v) {
                facing_up = true;
                spriteRenderer.sprite = spriteLookingUpward;
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