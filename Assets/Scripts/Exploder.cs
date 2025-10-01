
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explitionForce = 100f;
    [SerializeField] private float _explotionRadius = 10f;

    [SerializeField] private RayCaster _raycaster;
    

    public void Explode(Vector3 position, Collider[] cubes)
    {       
        foreach (var cube in cubes)
        {
            if(cube != null && cube.TryGetComponent(out Rigidbody rigidBody))
            {
                rigidBody.AddExplosionForce(_explitionForce, position, _explotionRadius);
            }
        }
    }
}
