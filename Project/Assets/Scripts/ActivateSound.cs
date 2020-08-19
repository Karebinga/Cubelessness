
using UnityEngine;

public class ActivateSound : MonoBehaviour
{
    public float accuracy;

    private bool _soundIsActive = false;
    private GameObject _player;

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
                Handheld.Vibrate();
                _soundIsActive = true;
                GetComponent<AudioSource>().Play(0);
            }
        }
    }
}
