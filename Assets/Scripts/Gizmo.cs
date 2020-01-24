using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    private void OnDrawGizmos() {
        Collider col = this.GetComponent<Collider>();
        float radius = col.bounds.extents.x - 0.05f;
        float fullDistance = 0.05f;
        Gizmos.DrawSphere(col.bounds.center - new Vector3(0, fullDistance, 0), radius);
    }
}
