using UnityEngine;
using DG.Tweening;

public class PlayerMovementTouch : MonoBehaviour
{
    [SerializeField]
    private int _gameEndCoordinates;
    [SerializeField]
    private float _controlSensibility;
    private Vector3 _mousePosition;
    private Vector3 _direction;
    private Vector3 _touchPoint;
    private float _playerTouchDistance;
    private float _groundBorder;

    private void Start()
    {
        _groundBorder = GameObject.Find("Ground").transform.localScale.x / 2; // Узнать размер дорожки
    }

    public void Update()
    {
        ControlTouch(); // Движение и повороты по тач-контролю
        //LevelEnd();
    }

    //void LevelEnd()
    //{
    //    if (gameObject.transform.position.z >= _gameEndCoordinates)
    //    {
    //        FindObjectOfType<GameManager>().CompleteLevel();
    //    }
    //}

    void ControlTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -1f * Camera.main.GetComponent<FollowPlayer>().offset.z));

            if (touch.phase == TouchPhase.Began)
            {
                _playerTouchDistance = _touchPoint.x - transform.position.x;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(Mathf.Clamp((_touchPoint.x - _playerTouchDistance) * _controlSensibility, -_groundBorder, _groundBorder),
                transform.position.y,
                transform.position.z);
            }
        }
    }
}

