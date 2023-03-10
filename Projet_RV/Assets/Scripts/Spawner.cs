using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] trash;
    [SerializeField] private float spawnRate;
    private float _timeToSpawn;
    void Start()
    {
        _timeToSpawn = spawnRate;
    }

    void Update()
    {
        _timeToSpawn -= Time.deltaTime;
        if (_timeToSpawn <= 0)
        {
            _timeToSpawn = spawnRate;
            var index = Random.Range(0, trash.Length);
            Instantiate(trash[index], transform.position, Quaternion.identity);
        }
    }
}
