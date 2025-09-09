using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _spawnMinCount = 2;
    [SerializeField] private int _spawnMaxCount = 6;
    [SerializeField] private float _startSplitChance = 1f;
    [SerializeField] private float _sizeReduce = 2f;
    [SerializeField] private float _chanceReduce = 2f;

    private Cube _cube;

    public void Create()
    {
        int cubeCount = CountCheck();
        float cubeSize = Resize();

        for (int i = 0; i <= cubeCount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            newCube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
            newCube._spawnChance /= _chanceReduce;
        }
    }

    private int CountCheck()
    {
        int count = UnityEngine.Random.Range(_spawnMinCount, _spawnMaxCount + 1);
        return count;
    }

    private float Resize()
    {
        float currentSize = _cube._size;
        float newSize = currentSize / _sizeReduce;

        return newSize;
    }
}
