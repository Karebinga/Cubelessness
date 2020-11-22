using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private GameObject _obstacleContainer;
    [SerializeField] private float _spawnFrequency;

    private bool _stopSpawning = false;
    private GameManager GameManager;
    private bool _coroutineRunning;
    private int durationCountdown;

    private void Start()
    {
        _stopSpawning = true;
        GameManager = FindObjectOfType<GameManager>();
    }

    public void StartSpawning()
    {
        _stopSpawning = false;
        StartCoroutine(SpawnObstacleRoutine());
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (!_stopSpawning && !_coroutineRunning)
        {
            _coroutineRunning = true;
            Vector3 posToSpawnn = new Vector3(Random.Range(-4f, 4f), 1, 100);
            int randomObstacle = Random.Range(0, _obstaclePrefab.Length);
            GameObject newObstacle = Instantiate(_obstaclePrefab[randomObstacle], posToSpawnn, Quaternion.identity);
            newObstacle.transform.parent = _obstacleContainer.transform;
            if (GameManager.IsGameOnPause)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(_spawnFrequency);
            }
           _coroutineRunning = false;

        }
    }
}
