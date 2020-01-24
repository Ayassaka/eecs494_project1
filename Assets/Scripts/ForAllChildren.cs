using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAllChildren : MonoBehaviour
{
    public void toggleAnimatorOfAllChildren(bool b) {
        foreach (Transform child in transform) {
            Animator anim = child.GetComponent<Animator>();
            ForAllChildren fac = child.gameObject.GetComponent<ForAllChildren>();
            if (anim != null) anim.enabled = b;
            if (fac != null) fac.toggleAnimatorOfAllChildren(b);
        }
    }
    public void setColorOfAllChildren(Color color) {
        foreach (Transform child in transform) {
            SpriteRenderer sr;
            ForAllChildren fac;
            sr = child.gameObject.GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = color;
            fac = child.gameObject.GetComponent<ForAllChildren>();
            if (fac != null) fac.setColorOfAllChildren(color);
        }
    }
}
