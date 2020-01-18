using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        if (!PlayerState.instance.isLongbeam) {
            Destroy(this.gameObject, lifeTime);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
