
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private int _minCubesCount = 2;
    [SerializeField] private int _maxCubesCount = 6;
    [SerializeField] private float _splitChanceReduction = 0.5f;
    [SerializeField] private float _scaleReduction = 0.5f;
    [SerializeField] private float _minScale = 0.1f;

    public Collider[] CreateCubes(Cube clickedCube, out Collider[] cubesColliders)
    {
        Vector3 position = clickedCube.transform.position;
        float scale = clickedCube.Scale;
        float splitChance = clickedCube.SplitChance;
        cubesColliders = null;


        if (scale <= _minScale)
        {
            Debug.Log("Размер = " + scale);
            Destroy(clickedCube.gameObject);
            return cubesColliders;
        }

        if (Random.value > splitChance)
        {
            Debug.Log("Шанс разделения = " + splitChance);
            Destroy(clickedCube.gameObject);
            return cubesColliders;
        }

        int randomCubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
        Collider[] cubes = new Collider[randomCubesCount];

        for (int i = 0; i < randomCubesCount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, position, Random.rotation);

            if (newCube.TryGetComponent<Cube>(out Cube cube))
            {
                cube.Init(scale * _scaleReduction, GetNextSplitChance(cube.SplitChance));
                cube.TryGetComponent<Collider>(out Collider cubeCollider);
                cubes[i] = cubeCollider;
            }
        }

        Destroy(clickedCube.gameObject);
        return cubes;
    }

    private float GetNextSplitChance(float splitChance)
    {
        return splitChance * _splitChanceReduction;
    }
}
