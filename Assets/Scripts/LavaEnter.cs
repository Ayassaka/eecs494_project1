using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEnter : MonoBehaviour
{
    // private void OnTriggerEnter(Collider other) {
    //     if (other.CompareTag("Player")) {
    //         //Rigidbody rb;
    //         //rb = GetComponent<Rigidbody>();
    //         //rb.velocity = Vector3.zero;
    //         //PlayerState.instance.groundController.SetActive(false);
    //         //PlayerState.instance.airController.SetActive(false);
    //         //PlayerState.instance.morphed.SetActive(false);
    //         //PlayerState.instance.Lava.SetActive(true);
    //         PlayerState.instance.enterlava();
    //         Debug.Log(other.gameObject);
    //         Debug.Log("enterlava");
    //         //GetComponent<PlayerRun>().JumpingMovespeed = 2;
    //         //GetComponent<PlayerRun>().Movespeed = 2;
    //         //GetComponentInChildren<PlayerGroundController>().jumpPower = 8;
    //         //PlayerState.instance.GetComponent<PlayerRun>().enabled = false;
    //     }
    // }
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(lavaStay());
        }
    }
    
    // private void OnTriggerExit(Collider other) {
    //     if (other.CompareTag("Player")) {
    //         PlayerState.instance.exitlava();
    //         Debug.Log("exitlava");
    //         //Rigidbody rb;
    //         //rb = GetComponent<Rigidbody>();
    //         //rb.useGravity = true;
    //         //PlayerState.instance.groundController.SetActive(false);
    //         //PlayerState.instance.airController.SetActive(true);
    //         //PlayerState.instance.morphed.SetActive(false);
    //         //PlayerState.instance.Lava.SetActive(false);
    //         //PlayerState.instance.GetComponent<PlayerRun>().enabled = true;
    //     }

    // }
    IEnumerator lavaStay() {
        PlayerState.instance.enterlava();
        
        yield return new WaitForSeconds(0.1f);
        PlayerState.instance.exitlava();
    }
}
