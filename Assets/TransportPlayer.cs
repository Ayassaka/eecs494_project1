using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPlayer : MonoBehaviour
{
    public float transportDuration = 3f;
    private void Update() {

    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        Debug.Log("enter");
        if (other.CompareTag("Player")) {
        Debug.Log("player");
            StartCoroutine(transporting());
        }
    }

    IEnumerator transporting() {
        Debug.Log("start transport");
        PlayerState.instance.GetComponent<ForAllChildren>().toggleAnimatorOfAllChildren(false);
        PlayerState.instance.controlable = false;


        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / transportDuration;
        
        Vector3 initial_pos = PlayerState.instance.gameObject.transform.position;
        Vector3 final_pos = initial_pos + PlayerState.instance.gameObject.transform.right * 3f;

        while(progress < 1.0f)
        {
            progress = (Time.time - initial_time) / transportDuration;
            PlayerState.instance.transform.position = Vector3.LerpUnclamped(initial_pos, final_pos, progress);
            yield return null;
        }

        PlayerState.instance.GetComponent<ForAllChildren>().toggleAnimatorOfAllChildren(true);
        PlayerState.instance.controlable = true;

    }
}
