using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int _spawnMinCount = 2;
    [SerializeField] private int _spawnMaxCount = 6;
    [SerializeField] private float _spawnScaleMult = 0.5f;
    [SerializeField] private float _spawnChanceReduce = 0.5f;

    public int SpawnGeneration = 0;

    public void Spawn()
    {
        if (SpawnAvableCheck())
        {
            float spawnScale = Mathf.Max(0.1f, 1f - _spawnScaleMult * SpawnGeneration);
            int spawnCount = UnityEngine.Random.Range(_spawnMinCount, _spawnMaxCount + 1);

            for (int i = 0; i < spawnCount; i++)
            {
                GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity);
                clone.transform.localScale = Vector3.one * spawnScale;

                ChangeColor(clone);
                SpawnerGenerationIncrease(clone);
            }
        }
    }

    private bool SpawnAvableCheck()
    {
        bool isSpawnAvable = true;
        float spawnChance = Mathf.Max(0f, 1f - _spawnChanceReduce * SpawnGeneration);

        if (prefab == null)
        {
            Debug.LogError("Prefab не назначен в инспекторе!");
            isSpawnAvable = false;
            return isSpawnAvable;
        }
        else if (UnityEngine.Random.value > spawnChance)
        {
            isSpawnAvable = false;
            return isSpawnAvable;
        }

        return isSpawnAvable;
    }

    private void ChangeColor(GameObject clone)
    {
        Renderer renderer = clone.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material = new Material(renderer.material);
            renderer.material.color = UnityEngine.Random.ColorHSV();
        }
    }

    private void SpawnerGenerationIncrease(GameObject clone)
    {
        Spawner cloneSpawner = clone.GetComponent<Spawner>();

        if (cloneSpawner != null)
            cloneSpawner.SpawnGeneration = this.SpawnGeneration + 1;
    }
}
