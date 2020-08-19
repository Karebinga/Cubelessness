using UnityEngine;

public class PlayerMovementTouch_OLD : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    public float ScreenWidth;
    public float forwardForce;

    void Start()
    {
        ScreenWidth = Screen.width;
        Debug.Log(ScreenWidth);
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce);
        Debug.Log(Input.touchCount);
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                Debug.Log(Input.GetTouch(i).position.x);
                rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                Debug.Log(Input.GetTouch(i).position.x);
                rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);
            }
            ++i;
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
   
