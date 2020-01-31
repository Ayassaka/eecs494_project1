using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
            GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked;
            GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
        }
    }
}
