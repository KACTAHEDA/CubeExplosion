
using UnityEngine;

public class ClickProcessor : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _rayCaster.CubeDetected += CubeClick;
    }

    private void OnDisable()
    {
        _rayCaster.CubeDetected -= CubeClick;
    }

    private void CubeClick(Cube cube)
    {
        Vector3 position = cube.transform.localPosition;

        _cubeFactory.CreateCubes(cube, out Collider[] cubes);

        if (cubes != null)
        {
            _exploder.Explode(position, cubes);
        }
    }
}
