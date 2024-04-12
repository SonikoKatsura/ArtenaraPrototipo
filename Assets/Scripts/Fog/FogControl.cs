using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class FogControl : MonoBehaviour {
    // Declaraci�n del delegado (CON PAR�METRO ADICIONAL)
    public delegate void FogValue(float fog);
    // Definici�n del evento
    public static event FogValue OnFogValue;


    public float densidadNiebla = 0.02f; // Ajusta este valor seg�n tus necesidades
    [SerializeField] PinchSlider pinchSlider;

    void Start() {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = densidadNiebla;
    }

    public void OnSliderChange() {
        float fog = pinchSlider.SliderValue / 100;
        RenderSettings.fogDensity = fog;

        //Evento Fog value
        if (OnFogValue != null)
            OnFogValue(fog);
    }
}

