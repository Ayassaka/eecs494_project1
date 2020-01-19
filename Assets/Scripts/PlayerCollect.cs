using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("longbeam")) {
            Destroy(other.gameObject);
            PlayerState.instance.isLongbeam = true;
        } else if (other.CompareTag("healthPickUp")) {
            Destroy(other.gameObject);
            PlayerState.instance.gainHealth(5);
        } else if (other.CompareTag("missilePickUp")) {
            Destroy(other.gameObject);
            PlayerState.instance.gainMissile(1);
        }
    }
}
