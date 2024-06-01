using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ColorDefiner _colorDefiner;
    [SerializeField] private Material _defaultMaterial;

    public event Action TouchedPlatform;
    private bool _isColored = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform) && _isColored == false)
        {
            TouchedPlatform?.Invoke();
            _isColored = true;
        }
    }

    public void SetDefaultColor()
    {
        _colorDefiner.SetMaterial(_defaultMaterial);
        _isColored = false;
    }
}