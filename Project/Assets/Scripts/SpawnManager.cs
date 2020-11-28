using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private GameObject _lightPrefab;
    [SerializeField] private GameObject _obstacleContainer;
    [SerializeField] private GameObject _lightsContainer;
    [SerializeField] private float _spawnFrequencyObstacle;
    [SerializeField] private float _spawnFrequencyLight;



    private bool _stopSpawning = false;
    private GameManager GameManager;
    private bool _coroutineObstacleRunning;
    private bool _coroutineLightsRunning;
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
        //StartCoroutine(SpawnLightsRoutine());
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

            Vector3 posToSpawnn = new Vector3(Random.Range(-3.8f, 3.8f), 1, 100);
            int randomObstacle = Random.Range(0, _obstaclePrefab.Length);
            GameObject newObstacle = Instantiate(_obstaclePrefab[randomObstacle], posToSpawnn, Quaternion.identity);
            newObstacle.transform.parent = _obstacleContainer.transform;

            if (GameManager.IsGameOnPause)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(_spawnFrequencyObstacle);
            }
            _coroutineObstacleRunning = false;
        }
    }

    //IEnumerator SpawnLightsRoutine()
    //{
    //    while (!_stopSpawning && !_coroutineLightsRunning)
    //    {
    //        _coroutineLightsRunning = true;
    //        Vector3 posToSpawn = new Vector3(0, 0, 100);
    //        GameObject newLight = Instantiate(_lightPrefab, posToSpawn, Quaternion.identity);
    //        newLight.transform.parent = _lightsContainer.transform;

    //        if (GameManager.IsGameOnPause)
    //        {
    //            yield return null;
    //        }
    //        else
    //        {
    //            yield return new WaitForSeconds(_spawnFrequencyLight);
    //        }
    //        _coroutineLightsRunning = false;
    //    }
    //}
}
