using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool transporting = false;

    public bool isTransporting() {
        return transporting;
    }

    public void setTranporting(bool b) {
        transporting = b;
        PlayerState.instance.GetComponent<ForAllChildren>().toggleAnimatorOfAllChildren(!b);
        PlayerState.instance.setControlable(!b);
    }
}
