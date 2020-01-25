using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 4f;
    public GameObject prefab;
    private void Update() {
        if (time < 4f) {
            time += Time.deltaTime;
        } else {
            float disx = PlayerState.instance.transform.position.x - transform.position.x;
            if (disx > -5f && disx < 5f) {
                Instantiate(prefab, transform.position, Quaternion.identity);
                time = 0;
            }
        }
    }

}
