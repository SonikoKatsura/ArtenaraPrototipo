using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Teleport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHeight : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float wantedPlayerHeight;
    private void Start()
    {
        var mixedRealityPlayspace = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        var camHeight = mainCamera.transform.position.y;
        var adjustement = wantedPlayerHeight - camHeight;

        mixedRealityPlayspace.position = new Vector3(mixedRealityPlayspace.position.x, mixedRealityPlayspace.position.y + adjustement, mixedRealityPlayspace.position.z);
    }

    public void OnTeleportCompleted(TeleportEventData eventData)
    {
        Debug.Log("Teleport Completed");
        var mixedRealityPlayspace = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        var camHeight = mainCamera.transform.position.y;
        var adjustement = wantedPlayerHeight - camHeight;

        mixedRealityPlayspace.position = new Vector3(mixedRealityPlayspace.position.x, mixedRealityPlayspace.position.y + adjustement, mixedRealityPlayspace.position.z);
    }

}
