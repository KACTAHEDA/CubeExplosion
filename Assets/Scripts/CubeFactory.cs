
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private CubeExplosion _cubeExplosion;

    [SerializeField] private int _minCubesCount = 2;
    [SerializeField] private int _maxCubesCount = 6;
    [SerializeField]private float _splitChanceReduction = 0.5f;
    [SerializeField]private float _scaleReduction = 0.5f;
    [SerializeField] private float _minScale = 0.1f;

    public void CreateCubes(Cube clickedCube)
    {
        Vector3 position = clickedCube.transform.position;
        float scale = clickedCube.Scale;
        float splitChance = clickedCube.SplitChance;


        if (scale <= _minScale)
        {
            Debug.Log("Размер = " + scale);
            Destroy(clickedCube.gameObject);
            return;
        }

        if (Random.value > splitChance)
        {
            Debug.Log("Шанс разделения = " + splitChance);
            Destroy(clickedCube.gameObject);
            return;
        }

        int randomCubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
        
        for (int i = 0; i < randomCubesCount; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, position, Random.rotation);
            Cube cube = newCube.GetComponent<Cube>();
            cube.Init(scale * _scaleReduction, clickedCube.GetNextSplitChance(_splitChanceReduction));
        }

        Destroy(clickedCube.gameObject);
        _cubeExplosion.Explode(position);
    }
}
