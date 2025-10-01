using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _cubesLayer;
    [SerializeField] private UserInput _userInput;

    public Action<Cube> CubeDetected;

    private void OnEnable()
    {
        _userInput.Clicked += CastRay;
    }

    private void OnDisable()
    {
        _userInput.Clicked -= CastRay;
    }

    private void CastRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        float rayDistance = 100f;

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, _cubesLayer))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeDetected?.Invoke(cube);
            }
        }
    }
}
