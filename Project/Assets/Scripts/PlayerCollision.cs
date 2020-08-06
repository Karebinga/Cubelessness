using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public New_PlayerMovementTouch movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }      
    }
}
