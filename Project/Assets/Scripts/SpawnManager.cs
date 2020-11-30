using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private GameObject _obstacleContainer;
    private static float _previousRuns;
    private bool _isFirstCube;
    private bool _stopSpawning = false;
    private GameManager _gameManager;
    private AudioSource _audio;
    private bool _coroutineObstacleRunning;
    private float nextTime;
    [SerializeField] private float _interval = 1f;

    private void Start()
    {
        _previousRuns = 0;
        _isFirstCube = true;
        _stopSpawning = true;
        _gameManager = FindObjectOfType<GameManager>();
        _audio = _gameManager.GetComponent<AudioSource>();
        nextTime = Time.timeSinceLevelLoad;
        Debug.Log("Start at" + nextTime);
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
        while (!_stopSpawning && !_coroutineObstacleRunning)
        {
            _coroutineObstacleRunning = true;
            
            Vector3 posToSpawnn = new Vector3(UnityEngine.Random.Range(-3f, 3f), 1, 120);
            int randomObstacle = UnityEngine.Random.Range(0, _obstaclePrefab.Length);
            GameObject newObstacle = Instantiate(_obstaclePrefab[randomObstacle], posToSpawnn, Quaternion.identity);
            newObstacle.transform.parent = _obstacleContainer.transform;

            if (_gameManager.IsGameOnPause)
            {
                yield return null;
            }
            else
            {
                Debug.Log("Before inteval" + nextTime);
                nextTime += _interval;
                if (_isFirstCube)
                {
                    _isFirstCube = false;
                    yield return new WaitForSeconds(_interval);
                }
                else
                {
                    yield return new WaitForSeconds(nextTime - Time.timeSinceLevelLoad);
                }
            }

            _coroutineObstacleRunning = false;
        }
    }
}
