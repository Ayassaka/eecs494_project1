using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowhealthsound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource aud;
    // Update is called once per frame
    void Update()
    {
        if (PlayerState.instance.health <= 8 && aud.loop == false) {
            aud.loop = true;
            aud.Play();
        }
        if (PlayerState.instance.health > 8 && aud.loop == true) {
            aud.loop = true;
            aud.Stop();
        }
    }
}
