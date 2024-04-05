using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogStart : MonoBehaviour {
    void Start() {
        FogEvent.instance.SetFogValue();
    }
}
