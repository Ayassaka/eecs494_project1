using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float lifeTime;
    public AudioClip aud;
    void Start()
    {
        AudioSource.PlayClipAtPoint(aud, transform.position);
        if (!PlayerState.instance.hasLongBeam) {
            Destroy(this.gameObject, lifeTime);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
