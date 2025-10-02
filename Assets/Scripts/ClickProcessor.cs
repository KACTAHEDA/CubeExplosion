
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
        Cube[] cubes = _cubeFactory.CreateCubes(cube);
        _exploder.Explode(position, cubes);
    }
}
