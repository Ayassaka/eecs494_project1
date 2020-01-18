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
    public int longpress;
    public bool isRunjump = false;
    public bool isRunning = false;
    bool isMorphed = false;
    public bool isJumping = false;
    public bool isGodMode = false;
    public static PlayerState instance;
    public bool isLongbeam = false;
    public int time;
    public int health = 30;
    public int missile = 30;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        time = 0;
        longpress = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            isGodMode = true;
            missile = 30;
            missiletext.text = "missile:" + missile.ToString();
        }
        if (isJumping) {
            time++;
            if (isGrounded() && time > 5) {
                standing.SetActive(true);
                morphed.SetActive(false);
                jump.SetActive(false);
                Runjump.SetActive(false);
                Run.SetActive(false);
                isJumping = false;
                time = 0;
                longpress = 0;
                isRunjump = false;
            }
        } else {
            if (!isMorphed) {
                if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    standing.SetActive(false);
                    morphed.SetActive(true);
                    jump.SetActive(false);
                    Runjump.SetActive(false);
                    Run.SetActive(false);
                    isMorphed = true;
                    longpress = 0;
                } else {
                    if (isJump()) {
                        longpress = 0;
                        isJumping = true;
                    } else {
                        if (isRun()) {
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
                }
            } else {
                if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded() && !isStuck()) {
                    standing.SetActive(true);
                    morphed.SetActive(false);
                    jump.SetActive(false);
                    Runjump.SetActive(false);
                    Run.SetActive(false);
                    isMorphed = false;
                    longpress = 0;
                }
            }
        }
        
    }

    bool isGrounded() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance)) {
            return true;
        }
        return false;
    }

    bool isStuck() {
        Collider col = this.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center, Vector3.up);
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = col.bounds.extents.y + 0.05f;
        if (Physics.SphereCast(ray, radius, fullDistance)) {
            return true;
        }
        return false;
    }
    bool isJump() {
        if (!isGrounded() && !isStuck() && Input.GetKeyDown(KeyCode.Z)) {
            return true;
        }
        return false;
    }
    bool isRun() {
        Rigidbody obj = this.GetComponent<Rigidbody>();
        if (isGrounded()) {
            if (Input.GetAxis("Horizontal") != 0) {
                return true;
            }
        }
        return false;
    }
    
}