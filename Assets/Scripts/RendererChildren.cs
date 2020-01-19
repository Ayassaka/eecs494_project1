using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererChildren : MonoBehaviour
{
    public void setColorOfAllChildren(Color color) {
        foreach (Transform child in transform) {
            SpriteRenderer sr;
            RendererChildren rc;
            sr = child.gameObject.GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = color;
            rc = child.gameObject.GetComponent<RendererChildren>();
            if (rc != null) rc.setColorOfAllChildren(color);
        }
    }
}

