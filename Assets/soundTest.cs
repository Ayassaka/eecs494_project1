using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTest : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip clip;
    void Start()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
