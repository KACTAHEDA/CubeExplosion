
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private int _minCubesCount = 2;
    [SerializeField] private int _maxCubesCount = 6;
    [SerializeField] private float _splitChanceReduction = 0.5f;
    [SerializeField] private float _scaleReduction = 0.5f;

    [SerializeField] public float MinScale => 0.1f;

    public Cube[] CreateCubes(Cube clickedCube)
    {
        Vector3 position = clickedCube.transform.position;
        float scale = clickedCube.Scale;
        float splitChance = clickedCube.SplitChance;

        int randomCubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
        Cube[] newCubes = new Cube[randomCubesCount];
       
        for (int i = 0; i < randomCubesCount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, position, Random.rotation);
            newCube.Init(scale * _scaleReduction, GetNextSplitChance(splitChance));
            newCubes[i] = newCube;
        }
       
        return newCubes;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private float GetNextSplitChance(float splitChance)
    {
        return splitChance * _splitChanceReduction;
    }
}
