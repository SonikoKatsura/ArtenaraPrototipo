using Meta.WitAi.Requests;
using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitAiListen : MonoBehaviour
{
    private AppVoiceExperience voiceExperience;

    void Start()
    {
        voiceExperience = GetComponent<AppVoiceExperience>();
        voiceExperience.VoiceEvents.OnComplete.AddListener(OnVoiceTranscription);
        voiceExperience.Activate();
    }

    // Update is called once per frame
    public void OnVoiceTranscription(VoiceServiceRequest _)
    {
        voiceExperience.Activate();
    }

    private void Update()
    {
        if (Input.anyKeyDown) 
        {
            Debug.Log("key");
            voiceExperience.Activate("volver");
        }
    }
}
