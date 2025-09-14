using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private Cube _cube;

    public void Explode(Cube oldCube)
    {
        _cube = oldCube;

        foreach (Rigidbody rigidbody in GetExplodableObjects())
        {
            rigidbody.AddExplosionForce(_explosionForce, _cube.transform.position, _explosionRadius);
        }

        Destroy(oldCube.gameObject);
    }
    
    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(_cube.transform.position, _explosionRadius);

        List<Rigidbody> rigidbodies = new();

        foreach (var collider in colliders)
        {
            if (collider.attachedRigidbody != null)
            {
                rigidbodies.Add(collider.attachedRigidbody);
            }
        }

        return rigidbodies;
    }
}
