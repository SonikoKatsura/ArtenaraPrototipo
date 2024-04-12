using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class FogControl : MonoBehaviour {
    // Declaración del delegado (CON PARÁMETRO ADICIONAL)
    public delegate void FogValue(float fog);
    // Definición del evento
    public static event FogValue OnFogValue;


    public float densidadNiebla = 0.02f; // Ajusta este valor según tus necesidades
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

