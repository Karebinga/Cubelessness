using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private GameManager GameManager;

    void Start()
    { 
        GameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (GameManager.IsGameOnPause == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
    }
}
