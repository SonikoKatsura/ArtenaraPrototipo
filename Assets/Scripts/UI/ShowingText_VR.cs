using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class ShowingText_VR : MonoBehaviour {
    public TextMesh text_1;
    public float timePerLetter = 0.05f;

    private string pTextOriginal;

    void Start() {
        pTextOriginal = text_1.text;   // Guarda el texto original        
        text_1.text = "";  // Borra el texto en pantalla

        // Inicia la rutina para mostrar el primer texto letra por letra
        StartCoroutine(ShowTextByLetter(text_1, pTextOriginal));
    }
    IEnumerator ShowTextByLetter(TextMesh textUI, string textoOriginal) {
        for (int i = 0; i < textoOriginal.Length; i++) {
            textUI.text += textoOriginal[i];
            yield return new WaitForSeconds(timePerLetter);
        }
    }
}
