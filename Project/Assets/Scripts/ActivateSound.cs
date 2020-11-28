using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivateSound : MonoBehaviour
{
    public float accuracy;
    public float jumpPower;
    public float jumpDuration;

    private bool _soundIsActive = false;
    private GameObject _player;
    private GameManager _gameManager;
    public float Speed;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _gameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (_soundIsActive == false && GameManager.GameHasStarted)
        {
            if (Mathf.Abs(gameObject.transform.position.z - _player.transform.position.z) <= accuracy)
            {
                gameObject.transform.DOJump(transform.position, jumpPower, 1, jumpDuration);
                _soundIsActive = true;
                GetComponent<AudioSource>().Play(0);
                _gameManager.PlusScore();
            }
        }
    }
}
