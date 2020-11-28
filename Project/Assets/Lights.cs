﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private GameManager GameManager;

    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, 3);
    }

    void Update()
    {
        if (GameManager.IsGameOnPause == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
    }
}
