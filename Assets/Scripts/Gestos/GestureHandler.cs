using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureHandler : MonoBehaviour, IMixedRealityGestureHandler<Vector3> {

    public GameObject objectToInstantiate; // Objeto que se instanciará al realizar el gesto

    private void OnEnable() {
        // Registra este script para recibir eventos de gestos
        //Con esto indicamos que queremos recibir todos los eventos de tipo IMixedRealityGestureHandler
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
    }

    private void OnDisable() {
        // Desregistra este script para dejar de recibir eventos de gestos
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
    }

    /*public void OnGestureComplete(InputEventData<Vector3> eventData) {
        // eventData.InputData
        // eventData.MixedRealityInputAction

    }*/


    public void OnGestureStarted(InputEventData eventData) {
        Debug.Log("GestureStarted");
        throw new System.NotImplementedException();
    }

    public void OnGestureUpdated(InputEventData eventData) {
        throw new System.NotImplementedException();
    }

    public void OnGestureUpdated(InputEventData<Vector3> eventData) {
        throw new System.NotImplementedException();
    }

    public void OnGestureCompleted(InputEventData<Vector3> eventData) {
        // Verifica si el gesto completado es el que estás buscando
        //if (eventData.MixedRealityInputAction.Description == "TuGestoEspecifico") {
            // Instancia el objeto en la posición del gesto completado
            Instantiate(objectToInstantiate, eventData.InputData, Quaternion.identity);
        //}
    }

    public void OnGestureCompleted(InputEventData eventData) {
        throw new System.NotImplementedException();
    }

    public void OnGestureCanceled(InputEventData eventData) {
        throw new System.NotImplementedException();
    }
}
