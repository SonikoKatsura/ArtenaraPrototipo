using Meta.WitAi.Requests;
using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AppVoiceExperience))]
public class ListenWit : MonoBehaviour { 
    private AppVoiceExperience voiceExperience;
    void Start() {
        voiceExperience = GetComponent<AppVoiceExperience>();
        voiceExperience.VoiceEvents.OnComplete.AddListener(OnVoiceTranscription);
        voiceExperience.Activate();
    }

    public void OnVoiceTranscription(VoiceServiceRequest _) {
        voiceExperience.Activate();
    }
}
