
using UnityEngine;

public class ActivateSound : MonoBehaviour
{
    public GameObject player;
    public float accuracy;
    public AudioClip clip;
    private bool SoundIsActive = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (SoundIsActive == false)
        {
            if (Mathf.Abs(gameObject.transform.position.z - player.transform.position.z) <= accuracy)
            {
                SoundIsActive = true;
                AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            }
        }
    }
}
