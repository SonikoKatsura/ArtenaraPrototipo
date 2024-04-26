using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiPointerHandler : MonoBehaviour, IMixedRealityFocusHandler, IMixedRealityPointerHandler
{
    public GameObject ventana;
    public float distance;

    public void OnFocusEnter(FocusEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    private void Update()
    {
        if (CoreServices.InputSystem.FocusProvider.TryGetFocusDetails(CoreServices.InputSystem.FocusProvider.PrimaryPointer, out Microsoft.MixedReality.Toolkit.Physics.FocusDetails focus))
        {
            // Calcular la posición deseada con un offset
            Vector3 desiredPosition = focus.Point + (focus.Point - transform.position).normalized * distance;

            // Establecer la posición deseada para la ventana
            ventana.transform.position = desiredPosition;

            // Calcular la dirección hacia la posición de enfoque
            Vector3 lookAtDirection = focus.Point - ventana.transform.position;

            // Rotar la ventana para que mire hacia el punto de enfoque
            Quaternion targetRotation = Quaternion.LookRotation(lookAtDirection);
            // Ajustar la rotación en el eje Y
            targetRotation *= Quaternion.Euler(0, 180, 0);
            ventana.transform.rotation = targetRotation;
        }
    }
}
