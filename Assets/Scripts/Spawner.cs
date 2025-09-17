using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _sizeReduce = 2f;
    [SerializeField] private float _chanceReduce = 2f;

    private Cube _currentCube;

    public List<Cube> Create(int spawnCount, Cube cube)
    {
        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < spawnCount; i++)
        {
            _currentCube = Instantiate(cube);
            InitializeCube();
            cubes.Add(_currentCube);
        }

        return cubes;
    }

    private void InitializeCube()
    {
        float cubeNewSize = _currentCube.Size / _sizeReduce;
        float newSpawnChance = _currentCube.SpawnChance / _chanceReduce;
        Vector3 newCubePosition = _currentCube.transform.position;

        _currentCube.Initialize(cubeNewSize, newSpawnChance, newCubePosition);
    }

    public void DestroyOldCube(Cube oldCube)
    {
        Destroy(oldCube.gameObject);
    }
}
