using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(Cube oldCube, List<Cube> newCubes)
    {
        foreach (Cube cube in newCubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidBody))
            {
                rigidBody.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
            }
        }
    }
}