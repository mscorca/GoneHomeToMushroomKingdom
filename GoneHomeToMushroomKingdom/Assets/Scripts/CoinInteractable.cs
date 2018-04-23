using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteractable : MonoBehaviour
{
    public GameObject AssociatedPlatform;
    private Vector3 _rotateValue;

    protected void Awake()
    {
        _rotateValue = new Vector3(1.5f, 0f, 0);
    }

    protected void Update()
    {
        transform.Rotate(_rotateValue);
    }

    public void ActivatePlatform()
    {
        AssociatedPlatform.SetActive(true);
        SoundManager.Instance.PlayCoinSound();
        gameObject.SetActive(false);
    }
}
