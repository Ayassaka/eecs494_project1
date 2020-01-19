using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireDirection : MonoBehaviour
{
    Animator anim;

    private void OnEnable() {
        anim = gameObject.GetComponent<Animator>();
        if (gameObject.GetComponentInParent<PlayerDirection>().isLookingUp()) {
            anim.SetTrigger("Upward");
        } else {
            anim.SetTrigger("Forward");
        }
    }

    public void setFireDirectionForward() {
        anim.SetTrigger("Forward");
    }
    public void setFireDirectionUpward() {
        anim.SetTrigger("Upward");
    }
}
