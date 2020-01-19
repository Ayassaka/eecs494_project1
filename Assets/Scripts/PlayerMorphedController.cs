using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMorphedController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.A)) {
            PlayerState.instance.deMorph();
        }
    }
}
