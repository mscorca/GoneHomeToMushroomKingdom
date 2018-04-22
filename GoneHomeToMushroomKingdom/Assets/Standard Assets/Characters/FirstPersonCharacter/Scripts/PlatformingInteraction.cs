using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlatformingInteraction : MonoBehaviour
{
    public AnimationCurve JumpCurve;
    //public Texture2D PlatformInteractImage;
    public Image PlatformInteractUI;

    private FirstPersonController _fpsController;
    private PlatformCollider _platformManager;
    private GameObject _currentPlatform;
    private Color _opaque;
    private Color _invisible;
    private bool _isJumping;

    // Lerp vars
    private float _lerpTime = 1.0f;
    private float _currentLerpTime;
    private Vector3 _lerpStartPos;
    private Vector3 _lerpEndPos;

    protected void Awake()
    {
        _fpsController = GetComponent<FirstPersonController>();
        _platformManager = GetComponentInChildren<PlatformCollider>();
        _invisible = PlatformInteractUI.color;
        _opaque = PlatformInteractUI.color;
        _opaque.a = 255;
        _invisible.a = 0;
        PlatformInteractUI.color = _invisible;
    }

    protected void Update()
    {
        if (_platformManager.Platforms.Count > 2)
        {
            GameObject closestPlatform = _platformManager.Platforms[0];
            foreach (GameObject platform in _platformManager.Platforms)
            {
                if (Vector3.Distance(transform.position, platform.transform.position) < Vector3.Distance(transform.position, closestPlatform.transform.position))
                {
                    closestPlatform = platform;
                }
            }
            _currentPlatform = closestPlatform;
        }
        else if (_platformManager.Platforms.Count == 1)
        {
            _currentPlatform = _platformManager.Platforms[0];
        }
        else
        {
            _currentPlatform = null;
            PlatformInteractUI.color = _invisible;
        }

        // Turn off UI
        if(_currentPlatform != null)
        {
            PlatformInteractUI.color = _opaque;
            if (Input.GetKeyDown(KeyCode.E) && !_isJumping && _fpsController.m_CharacterController.isGrounded)
            {
                _isJumping = true;
                _fpsController.IsScriptedJumping = true;
                _lerpStartPos = transform.position;
                _lerpEndPos = new Vector3(_currentPlatform.transform.position.x, 
                                          _currentPlatform.transform.position.y + _currentPlatform.transform.localScale.y/2 + 1,
                                          _currentPlatform.transform.position.z);
                _currentLerpTime = 0.0f;
            }
        }

        if (_isJumping)
        {
            InteractJump();
        }
    }

    // Have to lerp each pos individually because of y-axis curve
    private void InteractJump()
    {
        _currentLerpTime += Time.deltaTime;
        if (_currentLerpTime > _lerpTime)
        {
            _currentLerpTime = _lerpTime;
            _isJumping = false;
            _fpsController.IsScriptedJumping = false;
        }

        float percentLerped = _currentLerpTime / _lerpTime;

        float x = Mathf.Lerp(_lerpStartPos.x, _lerpEndPos.x, percentLerped);
        float y = Mathf.Lerp(_lerpStartPos.y, _lerpEndPos.y, percentLerped) * JumpCurve.Evaluate(percentLerped);
        float z = Mathf.Lerp(_lerpStartPos.z, _lerpEndPos.z, percentLerped);

        Debug.Log("Y: " + y);

        transform.position = new Vector3(x, y, z);

    }
}
