using UnityEngine;

public class PlayerMovementTouch : MonoBehaviour
{
    public float Speed;
    public int gameEndCoordinates;

    private float _deltaX;
    private RaycastHit _hit;
    private GameObject _ground;
    private float _border;

    private void Start()
    {
        _ground = GameObject.FindGameObjectWithTag("Ground");
        _border = _ground.transform.localScale.x / 2;
    }

    public void FixedUpdate()
    {
        ControlTouch();
        LevelEnd();
        Movement();
    }

    void Movement ()
    {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }



    void ControlTouch ()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(ray, out _hit))
                    {
                    _deltaX = _hit.point.x - transform.position.x;
                    }
                    break;

                case TouchPhase.Moved:
                    if (Physics.Raycast(ray, out _hit))
                    {
                        transform.position = new Vector3(Mathf.Clamp(_hit.point.x - _deltaX,-_border,_border),
                        transform.position.y,
                        transform.position.z);
                    }
                    break;

                /*
                 * case TouchPhase.Ended:
                    Time.timeScale = 0f;
                    GetComponent<AudioSource>().UnPause();
                break;
                */
            }
        }
    }

    void LevelEnd ()
    {
        if (gameObject.transform.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (gameObject.transform.position.z >= gameEndCoordinates)
        {
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
}
   
