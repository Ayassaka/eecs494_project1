using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpsound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource aud;
    

    // Update is called once per frame
    private void OnEnable() {
        if (PlayerState.instance.isJumping) {
            aud.Play();
        }
    }
}
