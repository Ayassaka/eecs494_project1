using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    PlayerDirection playerDirection;
    public GameObject bulletPrefab;
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
            GameObject bulletInstance = GameObject.Instantiate(bulletPrefab);
            PlayerState.instance.missile--;
            PlayerState.instance.missiletext.text = "missile:" + PlayerState.instance.missile.ToString();
            if (playerDirection.isLookingUp()) {
                bulletInstance.transform.position = firePostionUpward.position;
                bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(0, bulletSpeed, 0);
            } else {
                bulletInstance.transform.position = firePostionForward.position;
                if (playerDirection.isFacingRight()) {
                    bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(bulletSpeed, 0, 0);
                } else {
                    bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(-bulletSpeed, 0, 0);
                }
            }
        }
    }
}
