using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDiary : MonoBehaviour {

    public AudioClip audioMessage;

    public void OnClicked()
    {
        GetAudioClip();
    }

    public AudioClip GetAudioClip ()
    {
        return audioMessage;
    }
}    