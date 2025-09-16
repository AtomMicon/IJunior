using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Pointer _pointer;
    private Cube _currentCube;

    private void OnEnable()
    {
        _pointer.Pointed += DestroyOldCube;
    }
    private void OnDisable()
    {
        _pointer.Pointed -= DestroyOldCube;
    }

    public void Create()
    {
        _currentCube = Instantiate(_cubePrefab);
    }

    public void Initialize(float size, float spawnChance, Vector3 position)
    {
        _currentCube.Initialize(size, spawnChance, position);
    }

    public void DestroyOldCube(Cube oldCube)
    {
        Destroy(oldCube.gameObject);
    }
}
