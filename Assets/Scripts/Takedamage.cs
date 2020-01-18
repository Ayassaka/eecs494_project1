using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takedamage : MonoBehaviour
{
    // Start is called before the first frame update
    public float spriteBlinkingMiniDuration = 0.1f;
    public int spriteBlinkingTimes = 5;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            if (PlayerState.instance.isGodMode) {
                return;
            }
            StartCoroutine(blink(spriteBlinkingTimes));
            PlayerState.instance.health -= 8;
            StartCoroutine(becomegod());
            Vector3 Offset = new Vector3(-0.5f, 0, 0);
            transform.position = transform.position + Offset;
            if (PlayerState.instance.health <= 0) {
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            } else {
                PlayerState.instance.healthtext.text = "health = " + PlayerState.instance.health.ToString();
            }
        }
    }
    IEnumerator damage() {
        //PlayerState.instance.health -= 8;
        PlayerState.instance.standing.SetActive(false);
        PlayerState.instance.morphed.SetActive(true);
        PlayerState.instance.jump.SetActive(false);
        PlayerState.instance.Runjump.SetActive(false);
        PlayerState.instance.Run.SetActive(false);
        yield return new WaitForSeconds(1);
        PlayerState.instance.standing.SetActive(false);
    }

    IEnumerator blink(int blinkTimes) {
        for (int i = 0; i < blinkTimes; i++) {
            yield return new WaitForSeconds(spriteBlinkingMiniDuration);
            setVisibilityOfAllChildren(false);
            yield return new WaitForSeconds(spriteBlinkingMiniDuration);
            setVisibilityOfAllChildren(true);
        }
    }
    IEnumerator becomegod() {
        PlayerState.instance.isGodMode = true;
        yield return new WaitForSeconds(spriteBlinkingMiniDuration * spriteBlinkingTimes);
        PlayerState.instance.isGodMode = false;
    }

    void setVisibilityOfAllChildren(bool visible) {
        SpriteRenderer sr;
        foreach (Transform child in transform) {
            sr = child.gameObject.GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = (visible) ? Color.white : Color.grey;
        }
    }
}
