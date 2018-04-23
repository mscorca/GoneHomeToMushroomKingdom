using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    #region SINGLETON PATTERN
    public static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Bicycle");
                    _instance = container.AddComponent<SoundManager>();
                }
            }

            return _instance;
        }
    }
    #endregion

    public AudioClip CoinSound;
    public AudioClip AmbientMusic;
    public AudioClip RainTrack;
    private AudioSource _audioSource;

    protected void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(AmbientMusic);
        _audioSource.PlayOneShot(RainTrack);
    }

    public void PlayCoinSound()
    {
        _audioSource.PlayOneShot(CoinSound);
    }
}
