using UnityEngine;

public class PlayerMovementTouch : MonoBehaviour
{
    public float Speed;
    public int gameEndCoordinates;

    private float _deltaX;
    private RaycastHit _hit;

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

  /*  void Control ()
    {
        if ((Input.touchCount > 0) || (Input.GetMouseButton(0)))
        {
#if UNITY_EDITOR
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#else
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif
            if (Physics.Raycast(ray, out _hit))
            {
                gameObject.transform.position = new Vector3(
                    _hit.point.x, 
                    gameObject.transform.position.y, 
                    gameObject.transform.position.z);
            }
        }
    }
    */

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
                        _deltaX = _hit.point.x;
                        Debug.Log(_deltaX);
                    }
                    break;

                case TouchPhase.Moved:
                    if (Physics.Raycast(ray, out _hit))
                    { 
                        transform.position = new Vector3(_hit.point.x - _deltaX,
                        transform.position.y,
                        transform.position.z);
                        Debug.Log("Currnt position" + transform.position.x);
                        Debug.Log("Хит" + _hit.point.x);
                    }
                    break;
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
   
