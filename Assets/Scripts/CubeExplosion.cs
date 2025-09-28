
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explitionForce = 100f;
    [SerializeField] private float _explotionRadius = 10f;
    [SerializeField] private LayerMask _cubesLayer;

    public void Explode(Vector3 position)
    {
        Collider[] cubes = Physics.OverlapSphere(position, _explotionRadius, _cubesLayer);

        foreach (var cube in cubes)
        {
            if(cube != null && cube.TryGetComponent(out Rigidbody rigidBody))
            {
                rigidBody.AddExplosionForce(_explitionForce, position, _explotionRadius);
            }
        }
    }
}
