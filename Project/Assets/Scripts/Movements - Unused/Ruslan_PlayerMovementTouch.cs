using UnityEngine;

// YT 3_CX-KtsDic

public class Ruslan_New_PlayerMovementTouch : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    public float forwardForce;

    public float speedModifier;
    private Touch touch;

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce);
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            transform.position = new Vector3(transform.position.x + 
                touch.deltaPosition.x * speedModifier, 
                    transform.position.y, 
                    transform.position.z);
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
   
