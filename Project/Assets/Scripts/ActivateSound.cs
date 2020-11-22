using DG.Tweening;
using UnityEngine;

public class ActivateSound : MonoBehaviour
{
    public float accuracy;
    public float jumpPower;
    public float jumpDuration;

    private bool _soundIsActive = false;
    private GameObject _player;
    public float Speed;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    { 
        if (_soundIsActive == false)
        {
            if (Mathf.Abs(gameObject.transform.position.z - _player.transform.position.z) <= accuracy)
            {
                gameObject.transform.DOJump(transform.position, jumpPower, 1, jumpDuration);
                _soundIsActive = true;
                GetComponent<AudioSource>().Play(0);
            }
        }
    }
}
