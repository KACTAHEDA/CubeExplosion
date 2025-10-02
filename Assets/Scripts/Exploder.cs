
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explitionForce = 100f;
    [SerializeField] private float _explotionRadius = 10f;

    public void Explode(Vector3 position, Cube[] cubes)
    {       
        foreach (var cube in cubes)
        {
            if(cube != null)
            {
                cube.Rigidbody.AddExplosionForce(_explitionForce, position, _explotionRadius);
            }
        }
    }
}
