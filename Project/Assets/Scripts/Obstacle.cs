using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GameManager GameManager;

    void Start()
    { 
        GameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, 3);
    }

    void Update()
    {
        if (!GameManager.IsGameOnPause)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
        if (!GameManager.GameHasStarted)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 20);
        }
    }
}
