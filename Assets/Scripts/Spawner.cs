using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube Create()
    {
        Cube newCube = Instantiate(_cubePrefab);
        return newCube;
    }

    public void Destroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
