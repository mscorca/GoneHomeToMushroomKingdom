using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDiary : MonoBehaviour {

        public AudioClip audioMessage;

        private AudioSource source;

        // Use this for initialization
        void Start()
        {
            source = transform.GetComponent<AudioSource>();
        }

        public void OnClicked()
        {
            source.PlayOneShot(audioMessage);
        }
    }    