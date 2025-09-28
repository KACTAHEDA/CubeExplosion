
using UnityEngine;
using System;

public class UserInput : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] LayerMask _clickableLayer;

    public event Action<Cube> OnCubeClicked;

    private void Update()
    {
        UserActivity();
    }

    private void UserActivity()
    {
        var activity = Input.GetMouseButtonDown((int)MouseButton.Left);
        float rayDistance = 100f;

        if (activity)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, _clickableLayer))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    OnCubeClicked?.Invoke(cube);
                }
            }
        }
    }
}

