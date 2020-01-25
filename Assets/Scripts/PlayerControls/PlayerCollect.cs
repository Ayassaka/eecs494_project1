using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("LongBeamPowerUp")) {
            PlayerState.instance.hasLongBeam = true;
        } else if (other.CompareTag("MissilePowerUp" )) {
            PlayerState.instance.hasMissile = true;
        } else if (other.CompareTag("MorphBallPowerUp" )) {
            PlayerState.instance.hasMorphBall = true;
        } else if (other.CompareTag("healthPickUp" )) {
            PlayerState.instance.gainHealth(5);
        } else if (other.CompareTag("missilePickUp")) {
            PlayerState.instance.gainMissile(1);
        }
    }
}
