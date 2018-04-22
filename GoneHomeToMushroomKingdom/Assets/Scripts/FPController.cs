using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

[RequireComponent(typeof(CharacterController))]
public class FPController : MonoBehaviour
{
    private Vector2 _movementInput;
    private CharacterController _characterController;
    public float Speed;
    private Camera _camera;
    [SerializeField] private MouseLook _mouseLook;

    protected void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
        _mouseLook.Init(transform, _camera.transform);

    }

    protected void Update()
    {
        RotateView();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movementInput.x = horizontal;
        _movementInput.y = vertical;        
    }

    protected void FixedUpdate()
    {
        Vector3 desiredMove = transform.forward * _movementInput.y + transform.right * _movementInput.x;

        desiredMove *= Speed;
        _characterController.Move(desiredMove);

        _mouseLook.UpdateCursorLock();
    }


    private void RotateView()
    {
        _mouseLook.LookRotation(transform, _camera.transform);
    }

}
