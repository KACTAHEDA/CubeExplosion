
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private float _splitChance;
    private float _maxSplitChance = 1f;


    public float Scale => transform.localScale.x;
    public float SplitChance => _splitChance;

    private void Awake()
    {

        Init(Scale, SplitChance);
    }

    public void Init(float scale, float splitChance)
    {
        if (_splitChance == 0)
        {
            _splitChance = _maxSplitChance;
        }
        else
        {
            _splitChance = splitChance;
        }

        transform.localScale = Vector3.one * scale;

        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
    }

    public float GetNextSplitChance(float splitChanceReduction)
    {
        return _splitChance * splitChanceReduction;
    }
}
