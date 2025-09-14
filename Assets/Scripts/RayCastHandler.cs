using UnityEngine;

public class RayCastHandler : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _spawnMinCount = 2;
    [SerializeField] private int _spawnMaxCount = 6;
    [SerializeField] private float _sizeReduce = 2f;
    [SerializeField] private float _chanceReduce = 2f;

    private void OnEnable()
    {
        _pointer.Clicker += Explode;
    }

    private void OnDisable()
    {
        _pointer.Clicker -= Explode;
    }

    private void Explode(Cube cube)
    {
        if (SpawnCheck(cube) == true)
        {
            int spawnCount = SpawnCount();
            float cubeNewSize = cube.Size / _sizeReduce;
            float newSpawnChance = cube.SpawnChance / _chanceReduce;
            Vector3 newPosition = cube.transform.position;

            for (int i = 0; i < spawnCount; i++)
            {
                Color newColor = Random.ColorHSV();
                Cube newCube = _spawner.Create();
                newCube.Initialize(cubeNewSize, newSpawnChance, newColor, newPosition);
            }
        }

        _spawner.Destroy(cube);
    }

    private bool SpawnCheck(Cube cube)
    {
        float spawnChance = cube.SpawnChance;
        int spawnRoll = Random.Range(1, 100 + 1);
        bool isAvableSpawn = false;

        if (spawnRoll <= spawnChance)
            isAvableSpawn = true;

        return isAvableSpawn;
    }

    private int SpawnCount()
    {
        int spawnCount = Random.Range(_spawnMinCount, _spawnMaxCount + 1);
        return spawnCount;
    }
}
