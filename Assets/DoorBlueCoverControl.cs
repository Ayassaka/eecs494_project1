using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlueCoverControl : MonoBehaviour
{
    public GameObject doorCover;
    public float breakTime = 3f;
    public void breakCover() {
        StartCoroutine(_break_cover());
    }
    IEnumerator _break_cover() {
        doorCover.SetActive(false);
        yield return new WaitForSeconds(breakTime);
        doorCover.SetActive(true);
    }
}
