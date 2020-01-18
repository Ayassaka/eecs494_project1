using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBeam : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "longbeam") {
            Destroy(other.gameObject);
            PlayerState.instance.isLongbeam = true;
        }
    }
}
