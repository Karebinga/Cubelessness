using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovementTouch movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }      
    }
}
