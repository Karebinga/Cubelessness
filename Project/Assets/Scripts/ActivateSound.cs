using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivateSound : MonoBehaviour
{
    private float _jumpPower = 1f;
    private float _jumpDuration = 0.1f;
    private bool _soundIsActive = false;

    private GameObject _player;
    private GameManager _gameManager;
    private Transform _obstacle;
    private AudioSource _audio;

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
            _obstacle.transform.DOJump(new Vector3(_obstacle.transform.position.x,
                _obstacle.transform.position.y,
                _obstacle.transform.position.z - 3f), _jumpPower, 1, _jumpDuration);
            _obstacle.GetComponent<AudioSource>().Play(0);
            _gameManager.PlusScore();
        }
    }
}
