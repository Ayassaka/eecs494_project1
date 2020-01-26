using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEnter : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Lava")) {
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            PlayerState.instance.groundController.SetActive(false);
            PlayerState.instance.airController.SetActive(false);
            PlayerState.instance.morphed.SetActive(false);
            PlayerState.instance.Lava.SetActive(true);
            PlayerState.instance.inLava = true;
            //PlayerState.instance.GetComponent<PlayerRun>().enabled = false;
        }
    }
    /*
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Lava")) {
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            rb.useGravity = true;
            PlayerState.instance.groundController.SetActive(false);
            PlayerState.instance.airController.SetActive(true);
            PlayerState.instance.morphed.SetActive(false);
            PlayerState.instance.Lava.SetActive(false);
            PlayerState.instance.inLava = false;
            //PlayerState.instance.GetComponent<PlayerRun>().enabled = true;
        }

    }
    */
}
