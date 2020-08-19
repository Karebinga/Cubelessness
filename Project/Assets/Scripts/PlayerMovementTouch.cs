using UnityEngine;

public class PlayerMovementTouch : MonoBehaviour
{
    public float Speed;
    public int gameEndCoordinates;

    private RaycastHit _hit;

    public void FixedUpdate()
    {
        Movement();
        Control();
        LevelEnd();
    }

    void Movement ()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, Speed);
    }

    void Control ()
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
   
