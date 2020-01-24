using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkreebulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float lifeTime = 0.1f;
    public Vector3 Speed;
    private void OnEnable() {
        Destroy(this.gameObject, lifeTime);
    }
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("skreebullet")) {
            Destroy(this.gameObject);
        }
    }
}
