using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    PlayerDirection playerDirection;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform firePostionUpward;
    public Transform firePostionForward;
    public float bulletSpeed;
    // Start is called before the first frame update
    private void Awake() {
        playerDirection = this.GetComponentInParent<PlayerDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            fire(missilePrefab);
        }
    }

    void fire(GameObject prefab) {
        GameObject bulletInstance = GameObject.Instantiate(prefab);
        if (playerDirection.isLookingUp()) {
            bulletInstance.transform.position = firePostionUpward.position;
            bulletInstance.transform.rotation = Quaternion.identity;
            bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(0, bulletSpeed, 0);
        } else {
            bulletInstance.transform.position = firePostionForward.transform.position;
            if (playerDirection.isFacingRight()) {
                // bulletInstance.transform.rotation = Quaternion.LookRotation(Vector3.right);
                bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(bulletSpeed, 0, 0);
            } else {
                // bulletInstance.transform.rotation = Quaternion.LookRotation(Vector3.left);
                bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(-bulletSpeed, 0, 0);
            }
        }
    }
}
