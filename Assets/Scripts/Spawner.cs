using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube Create()
    {
        return Instantiate(_cubePrefab);
    }
}
