
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
        if (cube.Scale >= _spawner.MinScale && Random.value < cube.SplitChance)
        {
            Vector3 position = cube.transform.localPosition;
            Cube[] cubes = _spawner.CreateCubes(cube);
            _exploder.Explode(position, cubes);
        }

        _spawner.DestroyCube(cube);
    }
}
