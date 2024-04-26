using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFog : MonoBehaviour {

    public void FogToggle() {
        float fogValue = RenderSettings.fogDensity;
        if (fogValue == 0.1f)
            RenderSettings.fogDensity = 0.02f;
        else
            RenderSettings.fogDensity = 0.1f;
    }
}
