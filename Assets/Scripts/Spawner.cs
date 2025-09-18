using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _sizeReduce = 2f;
    [SerializeField] private float _chanceReduce = 2f;

    public List<Cube> Create(int spawnCount, Cube cube)
    {
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < spawnCount; i++)
        {
            Cube newCube = InitializeCube(Instantiate(cube));
            newCubes.Add(newCube);
        }

        return newCubes;
    }

    private Cube InitializeCube(Cube cube)
    {
        float cubeNewSize = cube.Size / _sizeReduce;
        float newSpawnChance = cube.SpawnChance / _chanceReduce;
        Vector3 newCubePosition = cube.transform.position;

        cube.Initialize(cubeNewSize, newSpawnChance, newCubePosition);
        
        return cube;
    }

    public void DestroyOldCube(Cube oldCube)
    {
        Destroy(oldCube.gameObject);
    }
}
