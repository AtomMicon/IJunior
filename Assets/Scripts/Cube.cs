using UnityEngine;

public class Cube : MonoBehaviour
{
    public float _size { get; private set; }
    public float _spawnChance = 100;
    private Spawner _spawner;
    private Explosioner _explosioner;

    private void Start()
    {
        _size = transform.localScale.x;
    }

    public void Explode()
    {
        if (SpawnCheck() == true)
            _spawner.Create();

        _explosioner.Destroy();
    }

    private bool SpawnCheck()
    {
        int spawnRoll = Random.Range(1, 100 + 1);
        bool isAvableSpawn = true;

        if (spawnRoll > _spawnChance)
            isAvableSpawn = false;

        return isAvableSpawn;
    }
}
