using UnityEngine;

public class New_2_PlayerMovementTouch : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    public float moveSpeedTouch;
    public float forwardForce;
    private Vector3 touchPosition;
    private Vector3 direction;


    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce);


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector3(direction.x, direction.y, direction.z) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
   
