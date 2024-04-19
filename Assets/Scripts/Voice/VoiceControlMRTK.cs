using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VoiceControlMRTK : MonoBehaviour {
    // Declaración del delegado (CON PARÁMETRO ADICIONAL)
    public delegate void FogValue(float fog);
    // Definición del evento
    public static event FogValue OnFogValue;

    public void LowFog() {
        Debug.Log("LowFog");
        float fog = 0.2f;

        //Evento Fog value
        if (OnFogValue != null)
            OnFogValue(fog);
    }
    public void MiddleFog() {
        Debug.Log("MiddleFog");
        float fog = 0.5f;

        //Evento Fog value
        if (OnFogValue != null)
            OnFogValue(fog);
    }
    public void MaxFog() {
        Debug.Log("MaxFog");
        float fog = 1;

        //Evento Fog value
        if (OnFogValue != null)
            OnFogValue(fog);
    }
}
