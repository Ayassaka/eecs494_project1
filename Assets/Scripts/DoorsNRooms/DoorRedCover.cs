using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRedCover : MonoBehaviour
{
    public int hitPoints = 5;
    public DoorRedCover opposingCover;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Missile")) {
            hitPoints--;
            if (hitPoints == 0) {
                Destroy(this.gameObject);
                Destroy(opposingCover.gameObject);
            }
        }
    }


}
