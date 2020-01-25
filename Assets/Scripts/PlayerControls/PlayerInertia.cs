using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInertia : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable() {
        PlayerState.instance.HorizontalInertia = true;
    }

    private void OnDisable() {
        PlayerState.instance.HorizontalInertia = false;
    }
}
