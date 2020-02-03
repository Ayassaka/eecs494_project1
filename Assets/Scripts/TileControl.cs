using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    private bool collided = false;
    private GameObject ob;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        if (other.GetContact(0).normal.y != 0 && !collided) {
            ob = (GameObject)Instantiate(prefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            collided = true;
            StartCoroutine(Moveob());
        }
    }
    IEnumerator Moveob() {
        for (int i = 0; i < 10; ++i) {
            Debug.Log("tile");
            ob.transform.position += new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
