using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private GameObject _obstacleContainer;

    private float _spawnFrequencyObstacle = 60.0f/30.0f;

    private bool _stopSpawning = false;
    private GameManager _gameManager;
    private bool _coroutineObstacleRunning;
    private float nextTime;
    [SerializeField] private float interval = 1f;

    private void Start()
    {
        _stopSpawning = true;
        _gameManager = FindObjectOfType<GameManager>();
    }


    public void StartSpawning()
    {
        _stopSpawning = false;
        StartCoroutine(SpawnObstacleRoutine());
        nextTime = Time.time;
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (!_stopSpawning && !_coroutineObstacleRunning)
        {
            _coroutineObstacleRunning = true;

            Vector3 posToSpawnn = new Vector3(Random.Range(-4f, 4f), 1, 120);
            int randomObstacle = Random.Range(0, _obstaclePrefab.Length);
            GameObject newObstacle = Instantiate(_obstaclePrefab[randomObstacle], posToSpawnn, Quaternion.identity);
            newObstacle.transform.parent = _obstacleContainer.transform;

            Debug.Log(Time.time);

            if (_gameManager.IsGameOnPause)
            {
                yield return null;
            }
            else
            {
                nextTime += interval;
                yield return new WaitForSeconds(nextTime - Time.time);
            }
            _coroutineObstacleRunning = false;
        }
    }
}
