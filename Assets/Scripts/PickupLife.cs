using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : MonoBehaviour
{
    public float pauseDuration = 2f;
    public float lifeTime = float.PositiveInfinity;
    public AudioClip clip;

    void OnEnable()
    {
        if (!float.IsPositiveInfinity(lifeTime)) {
            Destroy(this.gameObject, lifeTime);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(pause_game());
            if (clip != null) {
                AudioSource.PlayClipAtPoint(clip, transform.position);
            }
        }
    }

    IEnumerator pause_game() {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(pauseDuration);
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
