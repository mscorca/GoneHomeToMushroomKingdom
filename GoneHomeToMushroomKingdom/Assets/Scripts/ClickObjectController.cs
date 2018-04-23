using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObjectController : MonoBehaviour
{

    public float maxInteractDistance = 4.5f;

    private Camera _camera;

    // audio diaries
    private AudioClip currentAudioDiary;
    private AudioSource source;

    //notes
    private Text noteText;
    private Text currentNoteText; // used to grab rich text
    private Font currentFont;
    private Image notePaper;

    // Use this for initialization
    void Awake()
    {
        source = transform.GetComponent<AudioSource>();
        _camera = GetComponentInChildren<Camera>();
        currentAudioDiary = null;

        noteText = GetComponentInChildren<Text>();
        currentNoteText = noteText;
        currentFont = GetComponentInChildren<Text>().font;
        notePaper = GetComponentInChildren<Image>();
        notePaper.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // raycast within max interact distance
            if (Physics.Raycast(ray, out hit, maxInteractDistance))
            {
                // the object identified by hit.transform was clicked
                if (hit.transform.GetComponent<AudioDiary>() != null)
                {
                    currentAudioDiary = hit.transform.GetComponent<AudioDiary>().GetAudioClip();
                    PlayCurrentAudioDiary();
                }
                if (hit.transform.GetComponent<Note>() != null)
                {
                    currentNoteText = hit.transform.GetComponent<Note>().GetText();
                    currentFont = hit.transform.GetComponent<Note>().GetFont();
                    ReadCurrentNote();
                }
                if (hit.transform.GetComponent<CoinInteractable>() != null)
                {
                    hit.transform.GetComponent<CoinInteractable>().ActivatePlatform();
                }

            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            StopReadingCurrentNote();
        }
    }

    private void PlayCurrentAudioDiary()
    {
        // stop whatever is playing and restart just-clicked audio
        source.Stop();
        source.PlayOneShot(currentAudioDiary);
    }

    private void ReadCurrentNote()
    {
        notePaper.gameObject.SetActive(true);
        noteText.text = currentNoteText.text;
        transform.GetComponentInChildren<Text>().font = currentNoteText.font;
        noteText.enabled = true;
        notePaper.enabled = true;
    }

    private void StopReadingCurrentNote()
    {
        noteText.enabled = false;
        notePaper.enabled = false;
        notePaper.gameObject.SetActive(false);
    }
}
