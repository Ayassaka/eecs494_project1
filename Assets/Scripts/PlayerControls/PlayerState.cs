using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerState : MonoBehaviour
{
    public LayerMask wallLayer;

    public GameObject morphed;
    public GameObject airController;
    public GameObject groundController;
    public Text healthtext;
    public Text missiletext;
    public bool isJumping = false;
    public bool inLava = false;
    public int lavacount = 0;
    public bool HorizontalInertia = false;
    int stunned = 0;
    public bool isGodMode = false;
    public static PlayerState instance;
    public bool hasLongBeam = false;
    public bool hasMissile = false;
    public bool hasMorphBall = false;
    public bool MissileMode = false;
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
        // God Mode
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            isGodMode = true;
            max_missile = 99;
            gainMissile(max_missile);
            hasLongBeam = true;
            hasMissile = true;
            hasMorphBall = true;
        }
    }

    public void toggleMissileMode() {
        if (!hasMissile) return;
        if (MissileMode) {
            MissileMode = false;
            gameObject.GetComponent<ForAllChildren>().setColorOfAllChildren(Color.white);
        } else {
            MissileMode = true;
            gameObject.GetComponent<ForAllChildren>().setColorOfAllChildren(Color.cyan);
        }
    }

    public void gainHealth(int v) {
        health += v;
        if (health > max_health) health = max_health;
        healthtext.text = "Health: " + health.ToString();
    }
    public void loseHealth(int v) {
        health -= v;
        if (health <= 0) {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        } else {
            healthtext.text = "Health: " + health.ToString();
        }
    }

    public void gainMissile(int v) {
        missile += v;
        if (missile > max_missile) missile = max_missile;
        missiletext.text = "Missile: " + missile.ToString();
    }
    
    public bool useMissile() {
        if (missile == 0) return false;
        missile--;
        missiletext.text = "Missile: " + missile.ToString();
        return true;
    }


    public bool isGrounded() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.down);
        float radius = col.bounds.extents.x - 0.1f;
        float fullDistance = col.bounds.extents.y + 0.01f;
        if (Physics.SphereCast(ray, radius, fullDistance, wallLayer)) {
            return true;
        }
        return false;
    }

    public bool isStuck() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.up);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance, wallLayer)) {
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
        airController.SetActive(false);
        groundController.SetActive(true);
        GetComponentInChildren<PlayerGroundController>().enabled = true;
        morphed.SetActive(false);
    }
    //public AudioClip clip;
    public void leaveGround() {
        airController.SetActive(true);
        //GetComponent<AudioSourceControl>().JumpSound();
        GetComponentInChildren<PlayerGroundController>().enabled = false;
        groundController.SetActive(false);
        morphed.SetActive(false);
    }

    public void deMorph() {
        if (isGrounded()) {
            if (!isStuck()) {
                gameObject.transform.Translate(Vector3.up * .5f);
                hitGround();
            }
        } else {
            gameObject.transform.Translate(Vector3.up * .5f);
            leaveGround();
        }
    }

    public void morph() {
        if (!hasMorphBall) return;
        airController.SetActive(false);
        groundController.SetActive(false);
        morphed.SetActive(true);
    }

    public bool isControlable() {
        return stunned == 0;
    }

    public void setControlable(bool b) {
        if (b) stunned--;
        else stunned++; 
    }
    public void enterlava() {
        lavacount++;
        if (lavacount == 0) {
            inLava = false;
        } else {
            inLava = true;
        }
    }
    public void exitlava() {
        lavacount--;
        if (lavacount == 0) {
            inLava = false;
        } else {
            inLava = true;
        }
    }
}