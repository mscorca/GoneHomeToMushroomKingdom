using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScreen : MonoBehaviour {

    private bool _isFading;
    private float _fader = 255;
    private RawImage _image;
    private Color _imageColor;
    private Animator _anim;

    protected void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _anim.SetTrigger("Dofadeout");
	}
}
