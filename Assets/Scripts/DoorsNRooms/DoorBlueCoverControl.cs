using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlueCoverControl : MonoBehaviour
{
    public GameObject doorCover;
    public float breakTime = 3f;
    public void breakCover() {
        StartCoroutine(_break_cover(breakTime));
    }
    public IEnumerator _break_cover(float _breakTime) {
        doorCover.SetActive(false);
        yield return new WaitForSeconds(_breakTime);
        doorCover.SetActive(true);
    }
}
