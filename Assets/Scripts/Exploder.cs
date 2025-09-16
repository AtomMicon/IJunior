using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(Cube oldCube, List<Cube> newCubes)
    {
        foreach (var cube in newCubes)
        {
            if (cube.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
            }
        }
    }
}