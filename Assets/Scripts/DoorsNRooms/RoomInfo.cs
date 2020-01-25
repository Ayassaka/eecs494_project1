using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public int width = 1;
    public int height = 1;
    
    public bool isCameraBoundedHorizontally(float x, float freeZoneSize) {
        return x <= transform.position.x + 7.5f - freeZoneSize ||
            x >= transform.position.x + width * 16f - 8.5f + freeZoneSize;
    }

    public bool isCameraBoundedVertically(float y, float freeZoneSize) {
        return y <= transform.position.y + 7f - freeZoneSize ||
            y >= transform.position.y + height * 15f - 8f + freeZoneSize;
    }
}
