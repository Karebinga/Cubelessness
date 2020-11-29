using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovementTouch movement;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {
        movement.enabled = false;
        FindObjectOfType<GameManager>().EndGame();
        }
    }
}
