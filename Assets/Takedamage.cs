using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takedamage : MonoBehaviour
{
    // Start is called before the first frame update
    private bool visible = true;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    void Update()
     { 
         if(startBlinking == true)
         { 
             SpriteBlinkingEffect();
         }
     }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            if (PlayerState.instance.isGodMode) {
                return;
            }
            startBlinking = true;
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
    private void SpriteBlinkingEffect(){
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration) {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;   // according to 
                      //your sprite
            return;
        }
     
        spriteBlinkingTimer += Time.deltaTime;
        if(spriteBlinkingTimer >= spriteBlinkingMiniDuration){
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponentInChildren<SpriteRenderer> ().enabled == true) {
                this.gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = false;  //make changes
            } else {
                this.gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;   //make changes
            }
        }
    }
    IEnumerator becomegod() {
        PlayerState.instance.isGodMode = true;
        yield return new WaitForSeconds(spriteBlinkingTotalDuration);
        PlayerState.instance.isGodMode = false;
    }
}
