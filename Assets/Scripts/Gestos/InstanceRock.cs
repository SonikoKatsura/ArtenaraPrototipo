using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRock : MonoBehaviour {
    public GameObject objectToInstantiate;

    public void Instance () {
        Instantiate(objectToInstantiate, this.transform.position, Quaternion.identity);
    }
}
