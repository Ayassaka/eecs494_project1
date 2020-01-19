using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerState : MonoBehaviour
{

    public GameObject standing;
    public GameObject morphed;
    public GameObject jump;
    public GameObject Runjump;
    public GameObject Run;
    public Text healthtext;
    public Text missiletext;
    public bool isJumping = false;
    public bool isGodMode = false;
    public static PlayerState instance;
    public bool isLongbeam = false;
    public bool MissleMode = false;
    public int health = 30;
    public int max_health = 99;
    public int missile = 5;
    public int max_missile = 5;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            isGodMode = true;
            gainMissile(max_missile);
        }
    }

    public void gainHealth(int v) {
        health += v;
        if (health > max_health) health = max_health;
        healthtext.text = "Health: " + health.ToString();
    }

    public void gainMissile(int v) {
        missile += v;
        if (missile > max_missile) missile = max_missile;
        missiletext.text = "Missile: " + missile.ToString();
    }
    

    public bool isGrounded() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance)) {
            return true;
        }
        return false;
    }

    public bool isStuck() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.up);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance)) {
            return true;
        }
        return false;
    }

    public bool isRunning() {
        Rigidbody obj = this.GetComponent<Rigidbody>();
        return (Input.GetAxis("Horizontal") != 0);
    }
    
    public void hitGround() {
        isJumping = false;
        setRunning();
    }

    public void setRunning() {
        if (isRunning()) {
            standing.SetActive(false);
            morphed.SetActive(false);
            jump.SetActive(false);
            Runjump.SetActive(false);
            Run.SetActive(true);
        } else {
            standing.SetActive(true);
            morphed.SetActive(false);
            jump.SetActive(false);
            Runjump.SetActive(false);
            Run.SetActive(false);
        }
    }

    public void startRunning() {
        standing.SetActive(false);
        morphed.SetActive(false);
        jump.SetActive(false);
        Runjump.SetActive(false);
        Run.SetActive(true);
    }

    public void leaveGround() {
        if (isRunning()) {
            standing.SetActive(false);
            morphed.SetActive(false);
            jump.SetActive(false);
            Runjump.SetActive(true);
            Run.SetActive(false);
        } else {
            standing.SetActive(false);
            morphed.SetActive(false);
            jump.SetActive(true);
            Runjump.SetActive(false);
            Run.SetActive(false);
        }
    }

    public void deMorph() {
        if (isGrounded()) {
            if (!isStuck()) {
                hitGround();
            }
        } else {
            leaveGround();
        }
    }

    public void morph() {
        if (isGrounded()) {
            standing.SetActive(false);
            morphed.SetActive(true);
            jump.SetActive(false);
            Runjump.SetActive(false);
            Run.SetActive(false);
        }
    }
}