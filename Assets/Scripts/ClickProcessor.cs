
using UnityEngine;

public class ClickProcessor : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _rayCaster.CubeDetected += AfterClickOperations;
    }

    private void OnDisable()
    {
        _rayCaster.CubeDetected -= AfterClickOperations;
    }

    private void AfterClickOperations(Cube cube)
    {
        Vector3 position = cube.transform.localPosition;

        if (cube.Scale >= _spawner.MinScale && Random.value < cube.SplitChance)
        {
            _spawner.CreateCubes(cube);
        }
        else
        {
            _exploder.Explode(cube, _rayCaster.CubesInRadius(position, _exploder.ExplotionRadius));
        }

        _spawner.DestroyCube(cube);
    }
}
