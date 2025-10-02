
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private int _minCubesCount = 2;
    [SerializeField] private int _maxCubesCount = 6;
    [SerializeField] private float _splitChanceReduction = 0.5f;
    [SerializeField] private float _scaleReduction = 0.5f;
    [SerializeField] private float _minScale = 0.1f;

    public Cube[] CreateCubes(Cube clickedCube)
    {
        Vector3 position = clickedCube.transform.position;
        float scale = clickedCube.Scale;
        float splitChance = clickedCube.SplitChance;

        int randomCubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
        Cube[] newCubes = new Cube[randomCubesCount];

        if (scale <= _minScale)
        {
            Debug.Log("Размер = " + scale);
            Destroy(clickedCube.gameObject);
            return newCubes;
        }

        if (Random.value > splitChance)
        {
            Debug.Log("Шанс разделения = " + splitChance);
            Destroy(clickedCube.gameObject);
            return newCubes;
        }


        for (int i = 0; i < randomCubesCount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, position, Random.rotation);
            newCube.Init(scale * _scaleReduction, GetNextSplitChance(splitChance));
            newCubes[i] = newCube;
        }

        Destroy(clickedCube.gameObject);

        return newCubes;
    }

    private float GetNextSplitChance(float splitChance)
    {
        return splitChance * _splitChanceReduction;
    }
}
