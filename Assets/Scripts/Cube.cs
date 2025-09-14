using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _spawnChance;
    [SerializeField] private float _size;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Color _color;

    public float SpawnChance => _spawnChance;
    public float Size => _size;

    public void Initialize(float size, float spawnChance, Color color, Vector3 position)
    {
        _size = size;
        _spawnChance = spawnChance;
        _color = color;
        _position = position;

        SetCube();
    }

    private void SetCube()
    {
        transform.localScale = Vector3.one * _size;
        transform.position = _position;
        
        var renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = _color;
        }
    }
}
