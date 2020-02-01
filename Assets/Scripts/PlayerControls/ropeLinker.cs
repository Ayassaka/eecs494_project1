using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeLinker : MonoBehaviour
{
    public Rigidbody from;
    public Rigidbody to;

    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        lr.SetPosition(0, from.position);
        lr.SetPosition(1, to.position);
    }
}
