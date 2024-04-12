using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static InteractionHandlerScript;

public class GameManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI numOfGemsText;
    [SerializeField] GameObject DoorWin;
    [SerializeField] GameObject brokenDoor;
    [SerializeField] GameObject panelBrokenDoor;

    [SerializeField] float showinPanelTime = 5f;

    private int _numOfItems;
    private int _gemsCollected = 0;

    [SerializeField] bool showDoor = false;
    [SerializeField] bool showPanel = false;


    //SUSCRIPCIÓN al EVENTO
    void OnEnable() {
        InteractionHandlerScript.onGemCollected += OnCollectedGem;
        InteractionHandlerScript.onBrokenDoor += OnBrokenDoor;
    }
    //DESUSCRIPCIÓN al EVENTO
    void OnDisable() {
        InteractionHandlerScript.onGemCollected -= OnCollectedGem;
        InteractionHandlerScript.onBrokenDoor -= OnBrokenDoor;
    }

    void Start() {
        // Buscar todos los objetos con el tag "Item"
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        _numOfItems = items.Length;

        DoorWin.SetActive(false);
        brokenDoor.SetActive(true);
        panelBrokenDoor.SetActive(false);


        TextGemsLeft();
    }

    void Update() {
        DoorWin.SetActive(showDoor);
        brokenDoor.SetActive(!showDoor);
        if (showPanel) OnBrokenDoor();
    }

    private void TextGemsLeft() {
        int gemsLeft = _numOfItems - _gemsCollected;
        numOfGemsText.text = gemsLeft.ToString();
    }
    private void OnCollectedGem() {
        _gemsCollected++;
        //Debug.Log("Gemas recogidas: " + _gemsCollected);

        // Actualiza el texto de gemas faltantes
        TextGemsLeft();

        CheckWin();
    }
    private void OnBrokenDoor() {
        StartCoroutine(DisplayText());
    }
    IEnumerator DisplayText() {
        // Activar el objeto de texto
        panelBrokenDoor.SetActive(true);

        // Esperar el tiempo especificado
        yield return new WaitForSeconds(showinPanelTime);

        // Desactivar el objeto de texto después de haber transcurrido el tiempo especificado
        panelBrokenDoor.SetActive(false);
    }
    private void CheckWin() {
        if (_gemsCollected == _numOfItems) {

            brokenDoor.SetActive(false);
            DoorWin.SetActive(true);
        }
    }
}
