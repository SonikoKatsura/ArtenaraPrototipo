using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedStart : MonoBehaviour
{
    public GameObject Mixed1, Mixed2, Mixed3;
    // Start is called before the first frame update
    void Start()
    {
        Mixed1.SetActive(true);
        Mixed2.SetActive(true);
        Mixed3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
