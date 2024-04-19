using Unity.VisualScripting;
using UnityEngine;

// ---------------------------------------------------------------------------------
// SCRIPT PARA LA GESTI�N DE LA NIEBLA
// ---------------------------------------------------------------------------------


public class FogEvent : MonoBehaviour {
    // Creamos una variable est�tica para almacenar la �nica instancia
    public static FogEvent instance;

    [SerializeField] float fogValue;

    // M�todo Awake que se llama al inicio antes de que se active el objeto. �til para inicializar
    // variables u objetos que ser�n llamados por otros scripts (game managers, clases singleton, etc).
    private void Awake() {

        // ----------------------------------------------------------------
        // AQU� ES DONDE SE DEFINE EL COMPORTAMIENTO DE LA CLASE SINGLETON
        // Garantizamos que solo exista una instancia del SCManager
        // Si no hay instancias previas se asigna la actual
        // Si hay instancias se destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        // ----------------------------------------------------------------

        // No destruimos el SceneManager aunque se cambie de escena
        DontDestroyOnLoad(gameObject);

    }

    // Nos suscribimos al evento cuando se habilita el objeto ScoreManager
    private void OnEnable() {
        FogControl.OnFogValue += GetFogValue; // Suscribirse al evento
        VoiceControlMRTK.OnFogValue += GetSetFogValue;
    }
    // Nos damos de baja del evento cuando se deshabilita el objeto ScoreManager
    private void OnDisable() {
        FogControl.OnFogValue -= GetFogValue; // Baja del evento
        VoiceControlMRTK.OnFogValue -= GetSetFogValue;
    }

    public void GetFogValue(float fog) {
        fogValue = fog;
    }

    public void SetFogValue() {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = fogValue;
    }

    private void GetSetFogValue(float fog) {
        GetFogValue(fog/100);
        SetFogValue();
    }
}