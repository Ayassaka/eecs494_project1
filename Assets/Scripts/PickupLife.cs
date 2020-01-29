using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : MonoBehaviour
{
    public float pauseDuration = 2f;
    public float lifeTime = float.PositiveInfinity;
    public AudioSource aud;
    private bool soundPlay = false;
    public AudioClip clip;
    private void Start() {
        aud = GetComponent<AudioSource>();
            // AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    void OnEnable()
    {
        if (!float.IsPositiveInfinity(lifeTime)) {
            Destroy(this.gameObject, lifeTime);
        }
        
    }
    private void Update() {
        if (soundPlay) {
            Debug.Log(aud);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            soundPlay = true;
            StartCoroutine(pause_game());
        }
    }

    IEnumerator pause_game() {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(pauseDuration);
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
