using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkreeMovement : MonoBehaviour
{
    // Update is called once per frame
    private float velocityVertical = -8;
    public LayerMask wallLayer;
    public GameObject prefab;
    private bool hasInstantiate = false;
    Rigidbody rb;
    void Start() {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!isGrounded()) {
            if (detectplayer()) {
                Vector3 newVelocity = rb.velocity;
                newVelocity.y = velocityVertical;
                newVelocity.x = PlayerState.instance.transform.position.x - transform.position.x;
                rb.velocity = newVelocity;
            }
        } else {
            rb.velocity = Vector3.zero;
            if (!hasInstantiate) {
                StartCoroutine(blast());
            }
        }
    }

    bool detectplayer() {
        if (PlayerState.instance.transform.position.x > transform.position.x + 5f) {
            return true;
        }
        if (PlayerState.instance.transform.position.x < transform.position.x - 5f) {
            return false;
        }
        if (PlayerState.instance.transform.position.y < transform.position.y - 20f) {
            return false;
        }
        if (PlayerState.instance.transform.position.y > transform.position.y + 20f) {
            return false;
        }
        return true;
    }
    public bool isGrounded() {
        Collider col = this.GetComponent<Collider>();
        Vector3 zwxof = Vector3.up * 0.2f;
        Ray ray = new Ray(col.bounds.center + zwxof, Vector3.down);
        float radius = col.bounds.extents.x + 0.05f;
        float fullDistance = 0.2f;
        if (Physics.SphereCast(ray, radius, fullDistance + 0.2f, wallLayer)) {
            return true;
        }
        return false;
    }
    IEnumerator blast() {
        hasInstantiate = true;
        yield return new WaitForSeconds(1f);
        //for (int i = 0 ; i < 4; ++i) {
        //    Vector3 offset = new Vector3(Mathf.Cos(Mathf.PI * 1/3), Mathf.Sin(Mathf.PI * 1/3), 0);
        //    var obj = (GameObject)Instantiate(prefab, this.transform.position + offset, Quaternion.identity);
        //    obj.GetComponent<SkreebulletControl>().Speed = 
        //    new Vector3(Mathf.Cos(Mathf.PI * 1/3), Mathf.Sin(Mathf.PI * 1/3), 0);
        //}
        GameObject obj;
        Vector3 vec = new Vector3(20, 0, 0);
        for (int i = 0; i < 4; i++) {
            
            obj = (GameObject)Instantiate(prefab, this.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = vec;
            vec = Quaternion.Euler(0, 0, 60) * vec;
        }
        this.gameObject.SetActive(false);
    }
}
