using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public RoomInfo room;
    public float freeZoneSizeX = 1.2f;
    public float freeZoneSizeY = 1.8f;
    // Update is called once per frame
    void Update()
    {
        Vector3 cam_pos = transform.position;
        Vector3 player_pos = PlayerState.instance.transform.position;
        
        if (!room.isCameraBoundedHorizontally(player_pos.x, freeZoneSizeX)) {
            if (player_pos.x - cam_pos.x < -freeZoneSizeX) {
                cam_pos.x = player_pos.x + freeZoneSizeX;
            } else if (player_pos.x - cam_pos.x > freeZoneSizeX) {
                cam_pos.x = player_pos.x - freeZoneSizeX;
            }
        }
        if (!room.isCameraBoundedVertically(player_pos.y, freeZoneSizeY)) {
            if (player_pos.y - cam_pos.y < -freeZoneSizeY) {
                cam_pos.y = player_pos.y + freeZoneSizeY;
            } else if (player_pos.y - cam_pos.y > freeZoneSizeY) {
                cam_pos.y = player_pos.y - freeZoneSizeY;
            }
        }
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
}
