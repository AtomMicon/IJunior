using UnityEngine;

public class RayCastHandler : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _spawnMinCount = 2;
    [SerializeField] private int _spawnMaxCount = 6;
    [SerializeField] private float _sizeReduce = 2f;
    [SerializeField] private float _chanceReduce = 2f;

    private void OnEnable()
    {
        _pointer.Pointed += Explode;
    }

    private void OnDisable()
    {
        _pointer.Pointed -= Explode;
    }

    private void Explode(Cube cube)
    {
        if (CanSpawn(cube) == true)
        {
            int spawnCount = SpawnCount();
            float cubeNewSize = cube.Size / _sizeReduce;
            float newSpawnChance = cube.SpawnChance / _chanceReduce;
            Vector3 newPosition = cube.transform.position;

            for (int i = 0; i < spawnCount; i++)
            {
                _spawner.Create();
                _spawner.Initialize(cubeNewSize, newSpawnChance, newPosition);
            }
        }

        _exploder.Explode(cube);
    }

    private bool CanSpawn(Cube cube)
    {
        float spawnChance = cube.SpawnChance;
        int spawnRoll = Random.Range(1, 100 + 1);

        return spawnRoll <= spawnChance;
    }

    private int SpawnCount()
    {
        int spawnCount = Random.Range(_spawnMinCount, _spawnMaxCount + 1);
        return spawnCount;
    }
}
