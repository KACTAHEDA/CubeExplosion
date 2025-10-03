
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explitionForce = 100f;
    [SerializeField] private float _explotionRadius = 10f;

    public float ExplotionRadius => _explotionRadius;

    public void Explode(Cube cube, Cube[] cubes)
    {
        Vector3 position = cube.transform.localPosition;
        float sizeBonus = 1f / cube.Scale;
        float increasedForce = _explitionForce * sizeBonus;
        float increasedRadius = _explotionRadius * sizeBonus;

        foreach (var cubeInRadius in cubes)
        {
            if (cubeInRadius != null)
            {
                Vector3 cubePosition = cubeInRadius.transform.localPosition;
                Vector3 direction = (cubePosition - position).normalized;
                float distance = Vector3.Distance(cubePosition, position);
                float distanceFactor = Mathf.Clamp01(1f - (distance / increasedRadius));
                float force = increasedForce * distanceFactor;
                cubeInRadius.Rigidbody.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }
}
