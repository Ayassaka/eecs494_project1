using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlueCover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet") || other.CompareTag("Missile")) {
            GetComponentInParent<DoorBlueCoverControl>().breakCover();
        }
    }


}
