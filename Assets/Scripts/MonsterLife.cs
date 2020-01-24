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
    public GameObject[] dropPrefabs;
    public float[] dropRate;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            takeDamage(1);
            StartCoroutine(this.GetComponent<IStunable>().stun(.1f));
        } else if (other.CompareTag("Missile")) {
            die();
        }
    }

    void takeDamage(int damage) {
        hitPoints -= damage;
        if (hitPoints <= 0) {
            die();
        }
    }

    void die() {
        float dropLuck = Random.Range(0f, 1f);
        Destroy(this.gameObject);
        for (int i = 0; i < dropPrefabs.Length; ++i) {
            dropLuck -= dropRate[i];
            if (dropLuck <= 0) {
                GameObject.Instantiate(dropPrefabs[i], transform.position, Quaternion.identity);
                break;
            }
        }
        
        // TODO: blast
    }
}
