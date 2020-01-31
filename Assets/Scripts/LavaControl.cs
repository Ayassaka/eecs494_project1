// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class LavaControl : MonoBehaviour
// {
//     // Start is called before the first frame update
//     private Rigidbody rb;
//     private float time = 0;
//     private void Update() {
//         rb = GetComponentInParent<Rigidbody>();
//         rb.useGravity = false;
//         if (Input.GetKey(KeyCode.Z)) {
//             time += Time.deltaTime;
//             if (time > 0.8f) {
//                 rb.useGravity = true;
//                 PlayerState.instance.airController.SetActive(true);
//                 PlayerState.instance.Lava.SetActive(false);
//                 PlayerState.instance. = false;
//                 rb.velocity = (new Vector3(0, 8, 0));
//             }
//         } else {
//             time = 0;
//             rb.velocity = new Vector3(0, -0.5f, 0);
//             Vector3 newVelocity = rb.velocity;
//             newVelocity.x = Input.GetAxis("Horizontal") / 10;
//             rb.velocity = newVelocity;
//         }
//     }
// }
