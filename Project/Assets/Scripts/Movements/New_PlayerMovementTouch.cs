using UnityEngine;

public class New_PlayerMovementTouch : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce;
    private RaycastHit _hit;


    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce);

        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out _hit))
            {
                Debug.Log(_hit.point.x);
                gameObject.transform.position = new Vector3(_hit.point.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Debug.Log(gameObject.transform.position.x);
            }
        }
       
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
   
