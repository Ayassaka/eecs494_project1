using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPlayer : MonoBehaviour
{
    public float transportDistance = 3f;
    public float transportDuration = 3f;
    public float cameraMoveDuration = 1.8f;
    public float opposingCoverOpenDuration = .5f;


    public DoorBlueCoverControl opposingCover;

    DoorController dc;
    private void Update() {
        dc = GetComponentInParent<DoorController>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !dc.isTransporting()) {
            StartCoroutine(transporting());
            StartCoroutine(open_opposing_cover());
            StartCoroutine(wait_and_move_camera());
        }
    }

    IEnumerator transporting() {

        dc.setTranporting(true);

        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / transportDuration;
        
        Vector3 initial_pos = PlayerState.instance.gameObject.transform.position;
        Vector3 final_pos = initial_pos + PlayerState.instance.gameObject.transform.right * transportDistance;

        while(progress < 1.0f)
        {
            progress = (Time.time - initial_time) / transportDuration;
            PlayerState.instance.transform.position = Vector3.LerpUnclamped(initial_pos, final_pos, progress);
            yield return null;
        }

        dc.setTranporting(false);
    }

    IEnumerator open_opposing_cover() {
        yield return new WaitForSeconds(transportDuration - opposingCoverOpenDuration);
        yield return opposingCover._break_cover(opposingCoverOpenDuration);
    }

    IEnumerator wait_and_move_camera() {
        yield return new WaitForSeconds((transportDuration - cameraMoveDuration) / 2);
        
        float h_temp = (transportDistance > 0) ? 8 : -8;
        Vector3 from = transform.position + new Vector3(-h_temp, -1, -10);
        Vector3 to = transform.position + new Vector3(h_temp, -1, -10);
        yield return Camera.main.GetComponent<CameraFollower>().moveCameraOverTime(from, to, cameraMoveDuration);
    }
}
