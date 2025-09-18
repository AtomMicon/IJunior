using System.Collections.Generic;
using UnityEngine;

public class DivisionHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _pointer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _spawnMinCount = 2;
    [SerializeField] private int _spawnMaxCount = 6;
    [SerializeField] private int _spawnChanceMax = 100;
    [SerializeField] private int _spawnChanceMin = 1;

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
        List<Cube> newCubes = new List<Cube>();

        if (CanSpawn(cube))
        {
            newCubes = _spawner.Create(CalculateSpawnCount(), cube);
            _exploder.Explode(cube, newCubes);
            Debug.Log("Произошло разделение");
        }
        else
        {
            _exploder.Explode(cube);
        }

        _spawner.DestroyOldCube(cube);
    }

    private bool CanSpawn(Cube cube)
    {
        float spawnChance = cube.SpawnChance;
        int spawnRoll = Random.Range(_spawnChanceMin, _spawnChanceMax + 1);

        return spawnRoll <= spawnChance;
    }

    private int CalculateSpawnCount()
    {
        int spawnCount = Random.Range(_spawnMinCount, _spawnMaxCount + 1);
        return spawnCount;
    }
}
