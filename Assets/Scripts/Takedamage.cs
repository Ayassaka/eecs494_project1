using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takedamage : MonoBehaviour
{
    // Start is called before the first frame update
    public float spriteBlinkingMiniDuration = .1f;
    public float spriteStunDuration = .2f;
    public float spriteInertiaDuration = 1f;
    public int spriteBlinkingTimes = 5;
    public float knockBackPower = 50;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            if (PlayerState.instance.isGodMode) {
                return;
            }
            PlayerState.instance.loseHealth(8);

            StartCoroutine(becomegod());
            StartCoroutine(blink(spriteBlinkingTimes));
            StartCoroutine(knock_back(other.transform.position));
        }
    }

    IEnumerator knock_back(Vector3 position) {


        Vector3 direction = Vector3.Normalize(transform.position - position);
        
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().AddForce(direction * knockBackPower);
        PlayerState.instance.controlable = false;
        PlayerState.instance.HorizontalInertia = true;
        yield return new WaitForSeconds(spriteStunDuration);
        PlayerState.instance.controlable = true;
        yield return new WaitForSeconds(spriteInertiaDuration - spriteStunDuration);
        PlayerState.instance.HorizontalInertia = false;
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
        RendererChildren sr = gameObject.GetComponent<RendererChildren>();
        sr.setColorOfAllChildren((visible) ? Color.white : Color.grey);
    }
}
