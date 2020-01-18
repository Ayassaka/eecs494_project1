using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStunable
{
    IEnumerator stun(float time);
}
public class MonsterLife : MonoBehaviour
{
    public int hitPoints;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            takeDamage(1);
            StartCoroutine(this.GetComponent<IStunable>().stun(.1f));
        }
    }

    void takeDamage(int damage) {
        hitPoints -= damage;
        if (hitPoints <= 0) {
            Destroy(this.gameObject);
            // TODO: blast
        }
    }

}
