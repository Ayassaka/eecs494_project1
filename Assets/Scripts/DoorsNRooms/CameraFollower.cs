using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public RoomInfo room;
    public float freeZoneSizeX = 1.2f;
    public float freeZoneSizeY;

    public float moveHorizontalMax = 20f;
    private bool cameraMoving = false;
    private float tempy;
    // Update is called once per frame
    public float time;
    void Update()
    {
        Vector3 cam_pos = transform.position;
        Vector3 player_pos = PlayerState.instance.transform.position;
        if (Input.GetKey(KeyCode.DownArrow) && PlayerState.instance.isGrounded()) {
            cameraMoving = true;
            if (time < 2) {
                time += Time.deltaTime;
            }
            cam_pos.y = tempy - moveHorizontalMax * time;
        }
        // if (!room.isCameraBoundedHorizontally(player_pos.x, freeZoneSizeX)) {
        if (!cameraMoving){
            tempy = cam_pos.y;
            if (player_pos.x - cam_pos.x < -freeZoneSizeX) {
                cam_pos.x = player_pos.x + freeZoneSizeX;
            } else if (player_pos.x - cam_pos.x > freeZoneSizeX) {
                cam_pos.x = player_pos.x - freeZoneSizeX;
            }
        // }
        // if (!room.isCameraBoundedVertically(player_pos.y, freeZoneSizeY)) {
            if (player_pos.y - cam_pos.y < -freeZoneSizeY) {
                cam_pos.y = player_pos.y + freeZoneSizeY;
            } else if (player_pos.y - cam_pos.y > freeZoneSizeY) {
                cam_pos.y = player_pos.y - freeZoneSizeY;
            }
        }
        // }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            StartCoroutine(cameraMoveBack(time));
        }
        // cam_pos.x = PlayerState.instance.transform.position.x;
        // cam_pos.y = PlayerState.instance.transform.position.y;
        transform.position = cam_pos;
    }

    public void changeRoomTo(RoomInfo new_room) {
        room = new_room;
    }

    public IEnumerator moveCameraOverTime(Vector3 from, Vector3 to, float duration) {
        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / duration;

        while(progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration;
            transform.position = Vector3.LerpUnclamped(from, to, progress);
            yield return null;
        }
        transform.position = to;
    }
    IEnumerator cameraMoveBack(float t) {
        float currtime = t;
        time = 0;
        for (int i = 0; i < 10; ++i) {
            transform.position += new Vector3(0, moveHorizontalMax * t / 10, 0);
            yield return new WaitForSeconds(time / 10);
        }
        cameraMoving = false;
    }
}
