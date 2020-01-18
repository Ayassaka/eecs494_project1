using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    public float Movespeed = 5;
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerState.instance.isRunjump) {
            Vector3 newVelocity = rigid.velocity;
            newVelocity.x = Input.GetAxis("Horizontal") * Movespeed;
            rigid.velocity = newVelocity;
            
        }
        
        
    }
}
