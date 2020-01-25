using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : MonoBehaviour
{
    public float lifeTime = float.PositiveInfinity;
    void OnEnable()
    {
        if (!float.IsPositiveInfinity(lifeTime)) {
            Destroy(this.gameObject, lifeTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // if (other.CompareTag("Player")) {
        Destroy(this.gameObject);
        // }
    }
}
