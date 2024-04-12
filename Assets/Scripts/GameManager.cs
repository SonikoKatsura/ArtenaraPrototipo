using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI numOfGemsText;
    [SerializeField] GameObject DoorWin;
    [SerializeField] GameObject brokenDoor;

    private int _numOfItems;
    private int _gemsCollected = 0;

    [SerializeField] bool showDoor = false;


    //SUSCRIPCIÓN al EVENTO
    void OnEnable() {
        InteractionHandlerScript.onGemCollected += OnCollectedGem;
    }
    //DESUSCRIPCIÓN al EVENTO
    void OnDisable() {
        InteractionHandlerScript.onGemCollected -= OnCollectedGem;
    }

    void Start() {
        // Buscar todos los objetos con el tag "Item"
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        _numOfItems = items.Length;

        DoorWin.active = false;
        brokenDoor.active = true;

        TextGemsLeft();
    }

    void Update() {
        DoorWin.active = showDoor;
        brokenDoor.active = !showDoor;
    }

    private void TextGemsLeft() {
        int gemsLeft = _numOfItems - _gemsCollected;
        numOfGemsText.text = gemsLeft.ToString();
    }
    private void OnCollectedGem() {
        _gemsCollected++;
        Debug.Log("Gemas recogidas: " + _gemsCollected);

        // Actualiza el texto de gemas faltantes
        TextGemsLeft();

        CheckWin();
    }
    private void CheckWin() {
        if (_gemsCollected == _numOfItems) {

            brokenDoor.active = false;
            DoorWin.active = true;
        }
    }
}
