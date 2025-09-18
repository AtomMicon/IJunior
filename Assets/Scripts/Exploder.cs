using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _standartExplosionForce = 100f;
    [SerializeField] private float _standartExplosionRadius = 20f;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube oldCube, List<Cube> newCubes)
    {
        foreach (Cube cube in newCubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidBody))
            {
                rigidBody.AddExplosionForce(_standartExplosionForce, oldCube.transform.position, _standartExplosionRadius);
            }
        }
    }

    public void Explode(Cube oldCube)
    {
        UseEffect(oldCube);

        float explosionRadius =  _standartExplosionRadius / oldCube.Size;
        float explosionForce = _standartExplosionForce / oldCube.Size;

        foreach (Rigidbody rigidbody in GetExplodableObjects(oldCube, explosionRadius))
        {
            rigidbody.AddExplosionForce(explosionForce, oldCube.transform.position, explosionRadius);
        }

        Debug.Log($"Сила взрыва: {explosionForce}, Радиус врыва: {explosionRadius}");
    }

    private List<Rigidbody> GetExplodableObjects(Cube oldCube, float explosionRadius)
    {
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

    private void UseEffect(Cube oldCube)
    {
        ParticleSystem effect = Instantiate(_effect, oldCube.transform.position, oldCube.transform.rotation);
        effect.transform.localScale = Vector3.one / oldCube.Size;
    }
}