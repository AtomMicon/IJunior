using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 200f;
    [SerializeField] private float _explosionRadius = 4f;
    [SerializeField] private ParticleSystem _effect;

    public void ScatterNewCubes(Cube oldCube, List<Cube> newCubes)
    {
        foreach (Cube cube in newCubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidBody))
            {
                rigidBody.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
            }
        }
    }

    public void ExpolodeOldCube(Cube oldCube)
    {
        Instantiate(_effect, oldCube.transform.position, oldCube.transform.rotation);

        foreach (Rigidbody rigidbody in GetExplodableObjects(oldCube))
        {
            rigidbody.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube oldCube)
    {
        float explosionRadius = oldCube.Size * _explosionRadius;

        Collider[] colliders = Physics.OverlapSphere(oldCube.transform.position, explosionRadius);

        List<Rigidbody> rigidbodies = new();

        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody != null)
            {
                rigidbodies.Add(collider.attachedRigidbody);
            }
        }

        return rigidbodies;
    }
}