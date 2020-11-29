using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivateSound : MonoBehaviour
{
    private float _jumpPower;
    private float _jumpDuration;
    private bool _soundIsActive = false;

    private GameObject _player;
    private GameManager _gameManager;
    private Transform _obstacle;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _gameManager = FindObjectOfType<GameManager>();
        _obstacle = gameObject.transform.parent;
    }

    void OnTriggerEnter(Collider collider)
    {
        SoundActivation();
    }

    public void SoundActivation()
    {
        if (_soundIsActive == false && _gameManager.GameHasStarted)
        {
            _soundIsActive = true;
            _obstacle.DOJump(transform.position, _jumpPower, 1, _jumpDuration);
            _obstacle.GetComponent<AudioSource>().Play(0);
            _gameManager.PlusScore();
        }
    }
}
